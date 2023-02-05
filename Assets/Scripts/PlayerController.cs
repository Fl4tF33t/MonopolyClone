using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    Totem totem;
    Route route;
    NetworkObject networkObject;
    UIManager UIManager;

    int diceNumber1;
    int diceNumber2;

    public bool playerTurn = true;

    public event Action<int> OnDiceRoll;
    //public event Action<int> OnDiceRoll;

    public CSVReader.NodeData currentNode;

    // Start is called before the first frame update
    void Start()
    {
        totem = GetComponent<Totem>();
        //totem.OnEndOfMove += EndOfMove;
        route = GameObject.Find("Route").GetComponent<Route>();
        networkObject = GetComponent<NetworkObject>();
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        totem.OnEndOfMove += TestServerRpc;

    }

    // Update is called once per frame
    void Update()
    {
        DiceRoll();
    }

    //player's roll of the dice
    void DiceRoll()
    {
        if (IsOwner)
        {
            if (Input.GetKeyDown(KeyCode.Space) && totem.isMoving.Value == false && playerTurn)
            {
                diceNumber1 = UnityEngine.Random.Range(1, 7);
                diceNumber2 = UnityEngine.Random.Range(1, 7);
                OnDiceRoll?.Invoke(diceNumber1 + diceNumber2);
            };
        }
    }

    //option's after move
    /*void EndOfMove()
    {
        currentNode = route.childNodeList[totem.routePosition].gameObject.GetComponent<Node>();
        SONodes currentSONode = currentNode.currentNode;
        if(currentSONode.isOwned == false)
        {
            UIManager.buySellButtonText.text = "Buy";
        }
        else
        {
            UIManager.buySellButtonText.text = "Sell";

        }
    }*/

    [ServerRpc]
    void TestServerRpc()
    {
        currentNode = route.childNodeList[totem.routePosition].gameObject.GetComponent<Node>().nodeData;
        UIManager.testText.text = currentNode.nodeColor;
    }
}
