using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;

public class autojoin : MonoBehaviour
{
    public GameObject delete;
    public string IP;
    //[SerializeField] NetworkManager networkManager;
    [SerializeField] CanvasGroup canvas;
    
    void Start()
    {
        
    }
    
    public void JoinLocal()
    {
        bool delete_mode=delete.GetComponentInChildren<deleting>().delete_mode;
        if (delete.GetComponentInChildren<deleting>().delete_mode == false)
        {
            Debug.Log("autojoin.false");
           
            canvas.alpha = 0;
            // networkManager.networkAddress = IP;
            // networkManager.StartClient();
            using (StreamWriter writer = new StreamWriter(@"mode.txt"))
            {
                writer.WriteLine("client");
                writer.WriteLine(IP);
            }
            Debug.Log("Joining " + IP);
            Debug.Log("Trying to load a new scene");
            
            
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("autojoin.true");
        }
        
    }
}
