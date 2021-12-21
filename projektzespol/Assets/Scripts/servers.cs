using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.UI;


public class servers : MonoBehaviour
{
    public Transform position;
    public GameObject canvas;
    public GameObject button;
    public GameObject panel;
    public Transform panel2;
    [SerializeField] InputField server_name;
    [SerializeField] InputField server_IP;

    



    public void update_list()
    {
        foreach (Transform child in panel2)
        {
            GameObject noMore = new GameObject("IShouldNotExist!");
            child.transform.SetParent(noMore.GetComponent<Transform>());
            Destroy(noMore); //destroy the button (evil laugh) 
            /*
            Debug.Log(child.GetComponentInChildren<Text>().text);
            child.GetComponentInChildren<join_server>().get_name();*/
        }
        foreach (Transform child in panel2)
        {
            GameObject noMore = new GameObject("IShouldNotExist!");
            child.transform.SetParent(noMore.GetComponent<Transform>());
            Destroy(noMore); //destroy the button (evil laugh) 
            /*
            Debug.Log(child.GetComponentInChildren<Text>().text);
            child.GetComponentInChildren<join_server>().get_name();*/
        }
        using (StreamReader reader = new StreamReader(@"C:\Temp\test.txt"))
        {
            string line1;
            string line2;
            while ((line1 = reader.ReadLine()) != null)
            {
                line2 = reader.ReadLine();
                GameObject go = Instantiate(button);
                go.transform.SetParent(panel.transform, false);
                go.GetComponentInChildren<Text>().text = line1;
                go.GetComponentInChildren<join_server>().IP = line2;
            }
        }
    }

    void Start()
    {
        








        //string readText = File.ReadAllText(@"C:\Temp\test.txt");
        //string[] lines = readText.Split(Environment.NewLine);

        update_list();
        


        

        /*GameObject go = Instantiate(button);
        go.transform.SetParent(panel.transform, false);*/

    }

    public void Add_new()
    {
        GameObject go = Instantiate(button);
        go.transform.SetParent(panel.transform, false);
        go.GetComponentInChildren<Text>().text = server_name.text;
        go.GetComponentInChildren<join_server>().IP = server_IP.text;
        string readText = File.ReadAllText(@"C:\Temp\test.txt");
        using (StreamWriter writer = new StreamWriter(@"C:\Temp\test.txt"))
        {
            writer.Write(readText);
            writer.WriteLine(server_name.text);
            writer.WriteLine(server_IP.text);
        }
        
    }
    public void clear_list()
    {
        
        foreach (Transform child in panel2)
        {
            GameObject noMore = new GameObject("IShouldNotExist!");
            child.transform.SetParent(noMore.GetComponent<Transform>());
            Destroy(noMore); //destroy the button (evil laugh) 
            /*
            Debug.Log(child.GetComponentInChildren<Text>().text);
            child.GetComponentInChildren<join_server>().get_name();*/
        }
        foreach (Transform child in panel2)
        {
            GameObject noMore = new GameObject("IShouldNotExist!");
            child.transform.SetParent(noMore.GetComponent<Transform>());
            Destroy(noMore); //destroy the button (evil laugh) 
            /*
            Debug.Log(child.GetComponentInChildren<Text>().text);
            child.GetComponentInChildren<join_server>().get_name();*/
        }
        using (StreamWriter writer = new StreamWriter(@"C:\Temp\test.txt"))
        {
            writer.Write("");
        }


    }
    
 
   


}
