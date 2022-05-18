using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateLevels : MonoBehaviour
{

    [SerializeField] private GameObject[] collect = new GameObject[2];

    [SerializeField] private GameObject wait;
    [SerializeField] private GameObject checkPoint;
    [SerializeField] private GameObject helicopter;
    [SerializeField] private GameObject helicopterPosition;


    [SerializeField] private GameObject charcter; 
    [SerializeField] private GameObject charcterSpawnPoint;
    [SerializeField] private GameObject helicopterStored;
    [SerializeField] private GameObject[] platformMovement = new GameObject[3];
    [SerializeField] private GameObject[] level1Objects = new GameObject[20];
    [SerializeField] private GameObject[] level2Objects = new GameObject[32];
    [SerializeField] private GameObject[] level3Objects = new GameObject[40];

    private Vector3[] _level1ObjectsTransform = new Vector3[20];
    private Vector3[] _level2ObjectsTransform = new Vector3[32];
    private Vector3[] _level3ObjectsTransform = new Vector3[40];

    private SphereCollider _sphereCollider;
    private Rigidbody _rb;
    private SphereControl _sphereControl;
    private PlatformMovement[] _platformMovement= new PlatformMovement[3];

    private Wait _wait;
    private CheckPoint _checkPoint;
    private Helicopter _helicopter;

    private void Awake()
    {
        for (int i = 0; i < level1Objects.Length; i++)
        {
            _level1ObjectsTransform[i] = level1Objects[i].transform.position;
            
        }

        for (int i = 0; i < level2Objects.Length; i++)
        {
            _level2ObjectsTransform[i] = level2Objects[i].transform.position;
        }

        for (int i = 0; i < level3Objects.Length; i++)
        {
            _level3ObjectsTransform[i] = level3Objects[i].transform.position;
        }

        for (int i = 0; i < platformMovement.Length; i++)
        {
            _platformMovement[i] = platformMovement[i].GetComponent<PlatformMovement>();
        }
        

        _wait = wait.GetComponent<Wait>();
        _checkPoint = checkPoint.GetComponent<CheckPoint>();
        _helicopter = helicopter.GetComponent<Helicopter>();

    }


    public void RestartGame()
    {
        for (int i = 0; i < level1Objects.Length; i++)
        {
            level1Objects[i].gameObject.SetActive(true);
            _rb = level1Objects[i].GetComponent<Rigidbody>();
            _rb.velocity=new Vector3(0,0,0);
            Vector3 temp = _level1ObjectsTransform[i];
            level1Objects[i].transform.position = temp;
            level1Objects[i].transform.rotation = Quaternion.Euler(0,0,0);
            

        }

        for (int i = 0; i < level2Objects.Length; i++)
        {
            _rb = level2Objects[i].GetComponent<Rigidbody>();
            _rb.velocity = new Vector3(0, 0, 0);
            Vector3 temp = _level2ObjectsTransform[i];
            level2Objects[i].transform.position = temp;
            level2Objects[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            level2Objects[i].gameObject.SetActive(true);

        }

        for (int i = 0; i < level3Objects.Length; i++)
        {
            
            _sphereControl= level3Objects[i].GetComponent<SphereControl>();
            _sphereControl.enabled = false;
            _sphereCollider = level3Objects[i].GetComponent<SphereCollider>();
            _sphereCollider.enabled = false;
            _rb=level3Objects[i].GetComponent<Rigidbody>();
            _rb.velocity = new Vector3(0, 0, 0);
            _rb.useGravity = false;

            Vector3 temp = _level3ObjectsTransform[i];
            level3Objects[i].transform.position = temp;
            level3Objects[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            
            level3Objects[i].transform.SetParent(helicopterStored.transform);
            level3Objects[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < platformMovement.Length; i++)
        {
            _platformMovement[i].SetRestart(true);
        }

        for (int i = 0; i < collect.Length; i++)
        {
            collect[i].SetActive(true);
        }

        helicopter.transform.position = helicopterPosition.transform.position;
        charcter.transform.position = charcterSpawnPoint.transform.position;

        _wait.WaitStop();
        _checkPoint.LevelControlOff();
        _helicopter.StopDropBall();

    }

    public void SetItemFalse(int part)
    {
        switch (part)
        {
            case 1:
                for (int i = 0; i < level1Objects.Length; i++)
                {
                    level1Objects[i].SetActive(false);
                }
                break;
            case 2:
                for (int i = 0; i < level2Objects.Length; i++)
                {
                    level2Objects[i].SetActive(false);
                }
                break;
            case 3:
                for (int i = 0; i < level3Objects.Length; i++)
                {
                    level3Objects[i].SetActive(false);
                }
                break;
            default:
                break;
        }
    }

}
