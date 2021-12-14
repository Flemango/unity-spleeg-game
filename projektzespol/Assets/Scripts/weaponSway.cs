using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSway : MonoBehaviour
{
    public float amount = 0.1f;
    public float smooth_amount = 6f;
    Vector3 init_pos;

    void Start()
    {
        init_pos = transform.localPosition;
    }

    void Update()
    {
        float movement_x = -Input.GetAxis("Mouse X")*amount;
        float movement_y = -Input.GetAxis("Mouse Y")*amount;

        Vector3 final_pos = new Vector3(movement_x,movement_y,0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, final_pos+init_pos, Time.deltaTime*smooth_amount);
    }
}
