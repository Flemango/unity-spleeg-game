using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.UI;
public class apply_name : MonoBehaviour
{
    [SerializeField] InputField player_name;
    public void change_name()
    {
        using (StreamWriter writer = new StreamWriter(@"player_name.txt"))
        {
            writer.WriteLine(player_name.text);
        }
    }
}
