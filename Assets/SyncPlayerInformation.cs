using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncPlayerInformation : NetworkBehaviour {
    [SyncVar]
    public string _name;
    [SerializeField]
    List<Transform> playerList = new List<Transform>();
    [SerializeField]
    GameObject m_genki;
    private int playerCount = 0;

    void OnPlayerConnected(NetworkPlayer player)
    {
        if (isServer) {
            Debug.Log("Player " + playerCount++ + " connected from " + player.ipAddress + ":" + player.port);
        }
        else
        {
            Debug.Log("test");
        }
        Debug.Log("hello"); 
    }
    private void OnPlayerDisconnected(NetworkPlayer player)
    {
        
    }
    void Start()
    {



    }

    private void Update()
    {

        UpdatePlayersList();
        ListPlayer();
    }
    public void SetNameTo(string name)
    {
        if (isLocalPlayer)
        {
            CmdChangeName(name);
        }

    }
    [Command]
    public void CmdChangeName(string name) {
        _name = name;
    }
    public List<Transform> GetPlayers()
    {
        return playerList;
    }
    public void UpdatePlayersList()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            playerList.Add(p.transform);
        }
    }
    public void ListPlayer(){
        foreach (Transform t in playerList)
        {
            Debug.Log(t.name);
        }
    }
    public void ResizeGenki() {

        UpdatePlayersList();
        int i = playerList.Count;
        Vector3 size = new Vector3(i, i, i);

    }


}
