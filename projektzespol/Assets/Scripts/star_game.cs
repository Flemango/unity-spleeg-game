using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Mirror;

public class star_game : MonoBehaviour
{
    [SerializeField] NetworkManager networkManager;
    // Start is called before the first frame update
    void Start()
    {
        using (StreamReader reader = new StreamReader(@"mode.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "host")
                {
                    networkManager.StartHost();
                }
                else
                {
                    line = reader.ReadLine();
                    networkManager.networkAddress = line;
                    networkManager.StartClient();
                }
            }
        }
    }

    
}
