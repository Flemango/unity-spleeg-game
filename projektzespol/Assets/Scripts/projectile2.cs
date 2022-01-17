using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile2 : MonoBehaviour
{
    public GameObject explosion;
    public Transform thisObject;

    void Start()
    {
        Destroy(this.gameObject, 15);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 7)
        {
            Instantiate(explosion, thisObject.position, thisObject.rotation);

            Destroy(this.gameObject);
            Debug.Log("yay");
        }
    }
}