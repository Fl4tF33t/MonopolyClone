using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayerData : NetworkBehaviour
{
    public NetworkVariable<int> playerMoney = new NetworkVariable<int>();
    public NetworkVariable<List<int>> playerProperty = new NetworkVariable<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
        playerMoney.Value = 10;
        playerProperty.Value.Clear();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
