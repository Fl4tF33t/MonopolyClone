using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class GameManager : NetworkBehaviour
{
    NetworkManager networkManager;
    public List<int> currentPlayers = new List<int>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        networkManager.OnClientConnectedCallback += ConnectedPlayers;
        networkManager.OnClientDisconnectCallback += DisconnectedPlayers;       
    }

    
    //tracking who is connected and disconnects
    private void ConnectedPlayers(ulong player)
    {
        currentPlayers.Add(Convert.ToInt32(player));
    }
    private void DisconnectedPlayers(ulong player)
    {
        currentPlayers.Remove(Convert.ToInt32(player));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
