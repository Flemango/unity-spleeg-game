using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
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
