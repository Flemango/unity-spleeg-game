using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    public GameObject t;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(t, 10);
        // Start is called before the first frame update


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void self()
    {
        Destroy(t, 1);
    }
}
