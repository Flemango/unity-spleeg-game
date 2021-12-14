using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 15);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 7)
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            //Debug.Log("yay");
        }
    }
}
