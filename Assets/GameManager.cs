using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class GameManager : NetworkBehaviour
{
    NetworkManager networkManager;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        networkManager.OnClientConnectedCallback += ConnectedPlayers;
    }

    private void ConnectedPlayers(ulong obj)
    {
        Debug.Log(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
