using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerController : NetworkBehaviour
{
    Totem totemInfo;
    Route routeInfo;
    NetworkVariable<bool> playerCanMove = new NetworkVariable<bool>();
    public int playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        totemInfo = GetComponent<Totem>();
        routeInfo = GameObject.Find("Route").GetComponent<Route>();
        playerCanMove.Value = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = totemInfo.routePosition;
        if (Input.GetKeyDown(KeyCode.Space) && totemInfo.isMoving.Value == false && playerCanMove.Value == true)
        {
            playerCanMove.Value = false;
            totemInfo.steps = Random.Range(1, 7);
            StartCoroutine(totemInfo.Move());
        }
    }

    public void EndOfTurn()
    {
        Node currentNode = routeInfo.childNodeList[playerPosition].GetComponent<Node>();
        SONodes currentNodeInfo = currentNode.currentNode;
        NodeText nodeText = currentNode.GetComponentInChildren<NodeText>();
        nodeText.DisplayText(currentNodeInfo);
    }
}
