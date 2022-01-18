using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class die_msg : MonoBehaviour
{
    //public string text_value;
    public Text text_elem;

    void Update()
    {
        if(transform.position.y<-50)
            text_elem.text="You lost";
    }
}
