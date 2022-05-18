using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y > -1.485425f)
        {
            transform.position = new Vector3(transform.position.x, -1.485425f, transform.position.z);
        }

    }
}
