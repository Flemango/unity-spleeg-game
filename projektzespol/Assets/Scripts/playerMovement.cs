using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : NetworkBehaviour
{
    public float walking_speed = 5f;
    public float strafing_speed = 4f;
    public float horizontal_cam = 0;
    public float vertical_cam = 0;

    public float forward_move;
    public float side_move;
    public float vertical_move;
    public float jump_force = 5f;

    float mouse_sens=1.5f;

    CharacterController cc;
    public override void OnStartAuthority()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0.5f, 0);

    }
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!hasAuthority) return;
        horizontal_cam = Input.GetAxis("Mouse X");
        vertical_cam -= Input.GetAxis("Mouse Y");
        vertical_cam = Mathf.Clamp(vertical_cam, -90, 90);

        transform.Rotate(0, horizontal_cam, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(vertical_cam, 0, 0);

        forward_move = Input.GetAxis("Vertical") * walking_speed;
        side_move = Input.GetAxis("Horizontal") * strafing_speed;

        vertical_move += Physics.gravity.y * Time.deltaTime * 1.5f;

        if (cc.isGrounded) vertical_move = Mathf.Clamp(vertical_move, Physics.gravity.y/2, jump_force);
        else vertical_move = Mathf.Clamp(vertical_move, -30, jump_force);
        
        if (Input.GetButton("Jump") && cc.isGrounded)
        {
            vertical_move=jump_force;
            //Debug.Log(vertical_cam);
        }

        Vector3 player_move = new Vector3(side_move, vertical_move, forward_move);

        cc.Move(transform.rotation * player_move * Time.deltaTime);
    }
}
