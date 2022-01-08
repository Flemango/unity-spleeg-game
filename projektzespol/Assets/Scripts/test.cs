using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    
    public void  nowa()
    {
        Debug.Log("Trying to load a new scene");
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    public void host_mode()
    {
        
        using (StreamWriter writer = new StreamWriter(@"mode.txt"))
        {
            writer.WriteLine("host");
        }
    }
    
}
