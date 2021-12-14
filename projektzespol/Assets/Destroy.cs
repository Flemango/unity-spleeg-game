using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject d;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Test");
        if (collision.gameObject.layer==6)
        {
            Destroy(d);
           
        }
    }

}
