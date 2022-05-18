using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Helicopter : MonoBehaviour
{
    [SerializeField] private GameObject propeller;
    private int a= 0 ;


    [SerializeField] private GameObject[] levelThreeObjects = new GameObject[40];
    [SerializeField] private GameObject parent;
    [SerializeField] private Transform[] state;

    private SphereCollider[] _sphereCollider = new SphereCollider[40];
    private Rigidbody[] _rb = new Rigidbody[40];
    private Transform[] _transforms = new Transform[40];
    private SphereControl[] _sphereControl = new SphereControl[40];
    

    IEnumerator dropBall(float second)
    {

        transform.DOMoveZ(state[3].position.z,2);
        for (int i = 0; i < 10; i++)
        {
            levelThreeObjects[i].transform.SetParent(parent.transform);
            _sphereCollider[i].enabled = true;
            _rb[i].useGravity = true;
            yield return new WaitForSeconds(0.2f);
            _sphereControl[i].enabled = true;
        }
        transform.DOMoveX(state[1].position.x, 0.2f);
        transform.DOMoveZ(state[4].position.z, 2);

        for (int i = 10; i < 20; i++)
        {
            levelThreeObjects[i].transform.SetParent(parent.transform);
            _sphereCollider[i].enabled = true;
            _rb[i].useGravity = true;
            yield return new WaitForSeconds(0.2f);
            _sphereControl[i].enabled = true;
        }
        transform.DOMoveX(state[2].position.x, 0.2f);
        transform.DOMoveZ(state[5].position.z, 2);

        for (int i = 20; i < 30; i++)
        {
            levelThreeObjects[i].transform.SetParent(parent.transform);
            _sphereCollider[i].enabled = true;
            _rb[i].useGravity = true;
            yield return new WaitForSeconds(0.2f);
            _sphereControl[i].enabled = true;
        }
        transform.DOMoveX(state[1].position.x, 0.2f);
        transform.DOMoveZ(state[6].position.z, 2);

        for (int i = 30; i < 40; i++)
        {
            levelThreeObjects[i].transform.SetParent(parent.transform);
            _sphereCollider[i].enabled = true;
            _rb[i].useGravity = true;
            yield return new WaitForSeconds(0.2f);
            _sphereControl[i].enabled = true;
        }

        transform.DOMoveX(state[2].position.x, 0.2f);
        transform.DOMoveZ(state[0].position.z, 3);


    }
    
    private void Awake()
    {

        for (int i = 0; i < levelThreeObjects.Length; i++)
        {
            _transforms[i] = levelThreeObjects[i].GetComponent<Transform>();
        }
    }

    void Start()
    {
        for (int i = 0; i < levelThreeObjects.Length; i++)
        {
            _rb[i] = levelThreeObjects[i].GetComponent<Rigidbody>();
            _sphereCollider[i] = levelThreeObjects[i].GetComponent<SphereCollider>();
            _sphereControl[i] = levelThreeObjects[i].GetComponent<SphereControl>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        propeller.transform.rotation = Quaternion.Euler(0f,a, 0f);
        a+=2;
        if (a>360)
        {
            a = 0;
        }

    }
    public void StartDropBall() {
        StartCoroutine(dropBall(1f));
    }

    public void StopDropBall()
    {
        StopAllCoroutines();
    }
}
