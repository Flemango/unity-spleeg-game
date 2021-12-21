using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Threading.Tasks;


public class join_server : MonoBehaviour
{
     GameObject server_file;
    public GameObject button;
    GameObject delete;
    public GameObject connector;
    public string IP;

    public void change_IP()
    {
        delete = GameObject.Find("Delete one");
        bool delete_mode = delete.GetComponentInChildren<deleting>().delete_mode;

        if (delete_mode == false)
        {
            connector.GetComponentInChildren<autojoin>().IP = IP;
            connector.GetComponentInChildren<autojoin>().JoinLocal();
            Debug.Log("ip_false");
        }
        else
        {
            Debug.Log("ip_true");
            string name = button.GetComponentInChildren<Text>().text;
            string readText="";
            using (StreamReader reader = new StreamReader(@"C:\Temp\test.txt"))
            {
                string line1;
                string line2;
                while ((line1 = reader.ReadLine()) != null)
                {
                    line2 = reader.ReadLine();
                    if (line1 != name || line2 != IP)
                    {
                        readText = readText + line1+'\n';
                        readText = readText + line2+'\n';
                    }
                    
                }
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Temp\test.txt"))
            {
                writer.Write(readText);
            }
        }
        server_file = GameObject.Find("Servers");
        server_file.GetComponentInChildren<servers>().update_list();
           // o.GetComponentInChildren<join_server>().IP = line2;
    }
    public void get_name()
    {
        Debug.Log(IP);
    }
}
