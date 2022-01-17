using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class playerShooting : NetworkBehaviour
{
    public GameObject projectile;
    public GameObject projectile2;
    public weaponSwitch w_switch;
    public playerShooting player;
    public Transform player2;
    

    public float shoot_f, upward_f, shoot_cd, cd_timer;
    public GameObject attack;
    public Camera cam;
    public Transform attack_point;
    Vector3 target_point, direction;
    //Ray ray;
    bool bazooka_used=false;

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
        GameObject tmp = Instantiate(projectile2, attack_point.position, attack_point.rotation);

        float y_value;
        y_value=attack.GetComponentInChildren<attack_point>().tmp;
        
        float x_value;
        float z_value;
        x_value = Mathf.Cos(y_value * Mathf.Deg2Rad)*tmp.transform.forward.x;
        z_value = Mathf.Cos(y_value * Mathf.Deg2Rad)*tmp.transform.forward.z;


        if (y_value <= 0) y_value = Mathf.Sin(y_value * Mathf.Deg2Rad) * -1;
        else y_value = Mathf.Sin(y_value * Mathf.Deg2Rad) * -1;

        direction = new Vector3(x_value,y_value,z_value);
        tmp.GetComponent<Rigidbody>().velocity = direction*15;
        tmp.GetComponent<Rigidbody>().useGravity = false;
        Debug.Log(direction);
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
                if (bazooka_used==false)
                {
                    Bazooka();
                    bazooka_used=true;
                }
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
        /*
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        target_point = ray.GetPoint(10);

        direction = target_point - attack_point.position;

        GameObject current_projectile = Instantiate(projectile, attack_point.position, Quaternion.identity);
        current_projectile.GetComponent<Rigidbody>().AddForce(direction * shoot_f, ForceMode.Impulse);
        current_projectile.GetComponent<Rigidbody>().AddForce(direction * upward_f, ForceMode.Impulse);
        Debug.Log(w_switch.weapon_select);*/
        GameObject tmp = Instantiate(projectile, attack_point.position, attack_point.rotation);

        float y_value;
        y_value=attack.GetComponentInChildren<attack_point>().tmp;
        
        float x_value;
        float z_value;
        x_value = Mathf.Cos(y_value * Mathf.Deg2Rad)*tmp.transform.forward.x;
        z_value = Mathf.Cos(y_value * Mathf.Deg2Rad)*tmp.transform.forward.z;


        if (y_value <= 0) y_value = Mathf.Sin(y_value * Mathf.Deg2Rad) * -1;
        else y_value = Mathf.Sin(y_value * Mathf.Deg2Rad) * -1;

        direction = new Vector3(x_value,y_value,z_value);
        tmp.GetComponent<Rigidbody>().velocity = direction*30;
        Debug.Log(direction);
        //tmp.GetComponent<Rigidbody>().AddForce(direction * shoot_f*5, ForceMode.Impulse);
        //tmp.GetComponent<Rigidbody>().AddForce(direction * upward_f*5, ForceMode.Impulse);
        
    }
}
