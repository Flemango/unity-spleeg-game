using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class playerShooting : NetworkBehaviour
{
    public GameObject projectile;
    public weaponSwitch w_switch;
    public playerShooting player;
    

    public float shoot_f, upward_f, shoot_cd, cd_timer;

    public Camera cam;
    public Transform attack_point;
    Vector3 target_point, direction;
    Ray ray;

    void Start()
    {
        w_switch = FindObjectOfType<weaponSwitch>();
        cam = FindObjectOfType<Camera>();
    }
    
    void GunShoot()
    {
        if (!hasAuthority) return;
        NetworkIdentity netId = NetworkClient.connection.identity;
        player = netId.GetComponent<playerShooting>();
        if(isServer)
        {
            RpcShoot();
        }
        else
        {
            CmdShoot();
        }
        
        /*
        ray=cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        target_point=ray.GetPoint(10);
        
        direction=target_point-attack_point.position;

        GameObject current_projectile=Instantiate(projectile, attack_point.position, Quaternion.identity);
        current_projectile.GetComponent<Rigidbody>().AddForce(direction*shoot_f, ForceMode.Impulse);
        current_projectile.GetComponent<Rigidbody>().AddForce(direction*upward_f, ForceMode.Impulse);
        Debug.Log(w_switch.weapon_select);*/
    }

    void Bazooka()
    {

    }

    void Update()
    {
        if (!hasAuthority) return;
        if (cd_timer>0)
            cd_timer-=Time.deltaTime;

        if (cd_timer<0)
            cd_timer=0;

        if(Input.GetButton("Fire1") && cd_timer==0)
        {
            if (w_switch.weapon_select==0)
            {
                GunShoot();
                cd_timer=shoot_cd;
            }
            else {
                Bazooka();
            }
            
        } 
    }
    [Command]
    public void CmdShoot()
    {
        RpcShoot();
    }
    [ClientRpc]
    public void RpcShoot()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        target_point = ray.GetPoint(10);

        direction = target_point - attack_point.position;

        GameObject current_projectile = Instantiate(projectile, attack_point.position, Quaternion.identity);
        current_projectile.GetComponent<Rigidbody>().AddForce(direction * shoot_f, ForceMode.Impulse);
        current_projectile.GetComponent<Rigidbody>().AddForce(direction * upward_f, ForceMode.Impulse);
        Debug.Log(w_switch.weapon_select);
    }
}
