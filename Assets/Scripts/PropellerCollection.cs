using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerCollection : MonoBehaviour
{
    [SerializeField] private GameObject leftPropeller;
    [SerializeField] private GameObject rightPropeller;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Collect"))
        {

            leftPropeller.SetActive(true);
            rightPropeller.SetActive(true);
            gameObject.SetActive(false);


        }
    }
}
