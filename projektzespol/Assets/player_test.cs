using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class player_test : NetworkBehaviour
{
    [SyncVar]
    public int it=0;
    public player_test player;
    public GameObject test;
    [SerializeField] private Vector3 movement = new Vector3();
    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Server started");
    }

    void Start()
    {
       
        NetworkIdentity netId = NetworkClient.connection.identity;
        player = netId.GetComponent<player_test>();
        //super wa¿ne!
        //Warto aby by³ przt wywo³ywaniu jakiejkoliwek funkcji sieciowej
        transform.position = new Vector3(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5));
        //Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        
    }

    
    private void Update()
    {
        if (!hasAuthority) { return; }
        if (Input.GetButtonDown("Fire1"))
        {
            NetworkIdentity netId = NetworkClient.connection.identity;
            player = netId.GetComponent<player_test>();
            CmdCreateTest();
        }
        if (Input.GetMouseButtonDown(1))
        {
            NetworkIdentity netId = NetworkClient.connection.identity;
            player = netId.GetComponent<player_test>();

            if (isServer)
            {
                RpcDestroyTest();
            }
            else
            {
                CmdDestroyTest();
            }
            
        }
        if (!Input.GetKeyDown(KeyCode.Space)) { return; }
        transform.Translate(movement);
        
        
    }
    [Command]
    public void CmdCreateTest()
    {
        GameObject tmp = Instantiate(test, transform.position, transform.rotation);
        NetworkServer.Spawn(tmp,connectionToClient);
        
    }
    [ClientRpc]
    public void RpcDestroyTest()
    {
        if (it == 0)
        {
            Debug.Log("Test");
            Destroy(GameObject.Find("Test"));
        }
        else
        {
            Debug.Log("Test(" + it + ")");
            Destroy(GameObject.Find("Test (" + it + ")"));
        }
        it++;
       // Debug.Log("Fire3");
    }
    [Command]
    public void CmdDestroyTest()
    {
        //Debug.Log("Coœ siê dzieje");
        RpcDestroyTest();
    }
    //tmp.transform.SetParent(gameObject.transform, false);
}
