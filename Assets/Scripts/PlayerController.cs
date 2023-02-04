using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerController : NetworkBehaviour
{
<<<<<<< Updated upstream
    Totem totemInfo;
    Route routeInfo;
    NetworkVariable<bool> playerCanMove = new NetworkVariable<bool>();
    public int playerPosition;
=======
    Totem totem;
    Route route;
    NetworkObject networkObject;
    UIManager UIManager;

    int diceNumber1;
    int diceNumber2;

    public NetworkVariable<bool> playerTurn = new NetworkVariable<bool>(true);

    public event Action<int> OnDiceRoll;
    //public event Action<int> OnDiceRoll;

    public Node currentNode;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        totemInfo = GetComponent<Totem>();
        routeInfo = GameObject.Find("Route").GetComponent<Route>();
        playerCanMove.Value = true;
=======
        totem = GetComponent<Totem>();
        totem.OnEndOfMove += EndOfMove;
        route = GameObject.Find("Route").GetComponent<Route>();
        networkObject = GetComponent<NetworkObject>();
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = totemInfo.routePosition;
        if (Input.GetKeyDown(KeyCode.Space) && totemInfo.isMoving.Value == false && playerCanMove.Value == true)
        {
<<<<<<< Updated upstream
            playerCanMove.Value = false;
            totemInfo.steps = Random.Range(1, 7);
            StartCoroutine(totemInfo.Move());
=======
            if (Input.GetKeyDown(KeyCode.Space) && totem.isMoving.Value == false && playerTurn.Value == true)
            {
                diceNumber1 = UnityEngine.Random.Range(1, 7);
                diceNumber2 = UnityEngine.Random.Range(1, 7);
                OnDiceRoll?.Invoke(diceNumber1 + diceNumber2);
            };
>>>>>>> Stashed changes
        }
    }

    public void EndOfTurn()
    {
<<<<<<< Updated upstream
        Node currentNode = routeInfo.childNodeList[playerPosition].GetComponent<Node>();
        SONodes currentNodeInfo = currentNode.currentNode;
        NodeText nodeText = currentNode.GetComponentInChildren<NodeText>();
        nodeText.DisplayText(currentNodeInfo);
=======
        currentNode = route.childNodeList[totem.routePosition].gameObject.GetComponent<Node>();
        SONodes currentSONode = currentNode.currentNode.Value;

        //currentNode.ShowNodeData(currentSONode);
>>>>>>> Stashed changes
    }
}
