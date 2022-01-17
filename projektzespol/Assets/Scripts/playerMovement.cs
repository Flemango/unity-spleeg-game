using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.IO;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : NetworkBehaviour
{
    public weaponSwitch w_switch;

    public float walking_speed = 5f;
    public float strafing_speed = 4f;
    public float horizontal_cam = 0;
    [SyncVar(hook = "OnChange")]
    public float vertical_cam = 0;

    [SyncVar(hook = "OnWeaponChange")]
    public int weapon_select;

    public float forward_move;
    public float side_move;
    public float vertical_move;
    public float jump_force = 5f;

    float mouse_sens=1.5f;

    CharacterController cc;


    public TextMesh playerNameText;
    public GameObject floatingInfo;
    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;
    void OnNameChanged(string _Old, string _New)
    {
        playerNameText.text = playerName;
    }


    public override void OnStartLocalPlayer()
    {
        string name;

        if (File.Exists(@"player_name.txt"))
        {
            using (StreamReader reader = new StreamReader(@"player_name.txt"))
            {
                name = reader.ReadLine();
            }
        }
        else name = "Player" + UnityEngine.Random.Range(1, 1000);

        w_switch = FindObjectOfType<weaponSwitch>();




        CmdSetupPlayer(name);
    }
    [Command]
    public void CmdSetupPlayer(string _name)
    {
        // player info sent to server, then server updates sync vars which handles it on all clients
        playerName = _name;
        
    }


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
        if (!isLocalPlayer)
        {
            // make non-local players run this
            floatingInfo.transform.LookAt(Camera.main.transform);
            return;
        }


        if (isLocalPlayer)
        { 
            CmdVerticalSync(vertical_cam);
            weapon_select = w_switch.weapon_select;
            CmdWeaponSync(weapon_select);
        }


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
    [Command]
    public void CmdVerticalSync(float value)
    {
        vertical_cam = value;
    }
    void OnChange(float old,float value)
    {
        vertical_cam = value;
    }
    [Command]
    public void CmdWeaponSync(int value)
    {
        weapon_select = value;
    }
    void OnWeaponChange(int old, int value)
    {
        weapon_select = value;
    }
}
