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
    [SerializeField] InputField player_name;

    



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
        if (!File.Exists(@"test.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"test.txt"))
            {
                writer.WriteLine("local");
                writer.WriteLine("localhost");
            }
        }
        using (StreamReader reader = new StreamReader(@"test.txt"))
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



        if (!File.Exists(@"player_name.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"player_name.txt"))
            {
                writer.WriteLine("Player name");
            }
        }
        
        using (StreamReader reader = new StreamReader(@"player_name.txt"))
        {
           player_name.text= reader.ReadLine();
        }

        



        //string path = Directory.GetCurrentDirectory();
        // Debug.Log(path);

        update_list();
        


        

        

    }

    public void Add_new()
    {
        GameObject go = Instantiate(button);
        go.transform.SetParent(panel.transform, false);
        go.GetComponentInChildren<Text>().text = server_name.text;
        go.GetComponentInChildren<join_server>().IP = server_IP.text;
        string readText = File.ReadAllText(@"test.txt");
        using (StreamWriter writer = new StreamWriter(@"test.txt"))
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
        using (StreamWriter writer = new StreamWriter(@"test.txt"))
        {
            writer.Write("");
        }


    }
    
 
   


}
