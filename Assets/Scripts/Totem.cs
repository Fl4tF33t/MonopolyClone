using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class Totem : NetworkBehaviour
{
    //This script is used to ONLY control the rpc movement of the visual totem
    //Dont change script unless you have to, everything works fine here with the host and client as long as the route.childnodelist has been created

    Route route;
    PlayerController playerController;

    int steps;

    public int routePosition;
    public float movementSpeed;

    public NetworkVariable<bool> isMoving = new NetworkVariable<bool>();

    public event Action OnEndOfMove;

    // Start is called before the first frame update
    void Start()
    {
        route = GameObject.Find("Route").GetComponent<Route>();
        playerController = GetComponent<PlayerController>();
        playerController.OnDiceRoll += TotemMovement;
    }

    private void TotemMovement(int diceNumber)
    {
        steps = diceNumber;
        StartCoroutine("Move");
    }

    //Movement of the totem
    IEnumerator Move()
    {
        if (isMoving.Value == true)
        {
            yield break;
        }
        IsMovingServerRpc();

        while(steps > 0)
        {
            routePosition++;
            routePosition %= route.childNodeList.Count;

            Vector3 nextPos = route.childNodeList[routePosition].position;
            while (transform.position != nextPos)
            {
                MoveServerRpc(nextPos);

                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
            steps--;
            
        }
        IsNotMovingServerRpc();
        OnEndOfMove?.Invoke();
    }

    //NetworkVariable can not be change on client

    [ServerRpc]
    void IsMovingServerRpc()
    {
        isMoving.Value = true;
    }
    [ServerRpc]
    void IsNotMovingServerRpc()
    {
        isMoving.Value = false;
    }

    //ServerRpc needs to be a void so it can not be done inside a IEnumerator
    [ServerRpc]
    void MoveServerRpc(Vector3 goal)
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime);
    }
}
