using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deleting : MonoBehaviour
{
    public GameObject button;
    public Transform panel2;
    public bool delete_mode = false;

    public void change_mode()
    {
        if (delete_mode)
        {
            delete_mode = false;
            
            button.GetComponentInChildren<Text>().text = "delete mode off";

           


        }
        else
        {
            delete_mode = true;
            button.GetComponentInChildren<Text>().text = "delete mode on";
            
        }
    }
}
