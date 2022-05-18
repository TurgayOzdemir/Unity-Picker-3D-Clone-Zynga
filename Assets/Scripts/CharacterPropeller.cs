using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPropeller : MonoBehaviour
{
    [SerializeField] private GameObject leftPropeller;
    [SerializeField] private GameObject rightPropeller;

    private float a=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftPropeller.transform.rotation = Quaternion.Euler(0f,a ,0f);
        rightPropeller.transform.rotation = Quaternion.Euler(0f,-a ,0f);

        a+=3;
        if (a>360)
        {
            a = 0;
        }
    }
}
