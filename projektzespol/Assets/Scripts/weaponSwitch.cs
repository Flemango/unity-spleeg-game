using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class weaponSwitch : MonoBehaviour
{
    public int weapon_select=0;
    public bool anim_cooldown=false;
    public bool animation=false;
    public Transform child;

    public Vector3 anim_start;
    public Vector3 anim_end;

    int active;

    void selectWeapon()
    {
        int i=0;
        foreach (Transform weapon in transform)
        {
            if (i==weapon_select)
            {
                weapon.gameObject.SetActive(true); 
                active=i;
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void startAnimation()
    {
        anim_cooldown=true;

        child=this.gameObject.transform.GetChild(active);
        anim_start = child.gameObject.transform.localPosition;
        anim_end = new Vector3(anim_start.x, anim_start.y-0.25f, anim_start.z);
        child.GetComponent<weaponSway>().enabled = false;
        animation=true;

        //anim_cooldown=false;
    }

    void Start()
    {
        selectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim_cooldown)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                //startAnimation();
                weapon_select++;
                weapon_select%=transform.childCount;

                selectWeapon();
                //Debug.Log(weapon_select);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                //startAnimation();
                weapon_select--;
                weapon_select%=transform.childCount;
                weapon_select=Math.Abs(weapon_select);

                selectWeapon();
                //Debug.Log(weapon_select);
            }
        }
        
        /*if(animation)
        {
            child.gameObject.transform.localPosition = Vector3.Lerp(anim_start, anim_start+anim_end, Time.deltaTime*6);

            if (child.gameObject.transform.localPosition.y >= anim_end.y)
            {
                animation=false;
                selectWeapon();
            }
        }*/
    }
}
