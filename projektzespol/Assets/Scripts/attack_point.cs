using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class attack_point : MonoBehaviour
{

    
    public float tmp;

    public GameObject player;
    public Camera cam;
    public Transform attack;
    
    public float offset=-.3f;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
    
        //button.GetComponentInChildren<Text>().text = "delete mode on";
     
        tmp = player.GetComponentInChildren<playerMovement>().vertical_cam;
        
        
            
        //if (tmp == 90) transform.position.y = 1;
        // else if (tmp == -90) transform.position.y = -1;
        //attack.localRotation=Quaternion.Euler(tmp, 0, 0);
        if (tmp <= 0) transform.localPosition = new Vector3(transform.localPosition.x,0.4f+(Mathf.Sin(tmp*Mathf.Deg2Rad) *offset), 1f-(Mathf.Sin(tmp * Mathf.Deg2Rad) * offset));
        else transform.localPosition = new Vector3(transform.localPosition.x, 0+Mathf.Cos(tmp*Mathf.Deg2Rad)/2, 0);

        //Debug.Log(tmp);
        //Debug.Log(transform.localPosition);
        /*
        if (tmp == 90) transform.localPosition = new Vector3(0, 0, 0);
        else if(tmp== -90) transform.localPosition = new Vector3(0, 1, 0);*/
    }
    
}
