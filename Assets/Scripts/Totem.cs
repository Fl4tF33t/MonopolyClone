using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class Totem : NetworkBehaviour
{
    Route currentRoute;
    public int routePosition;

    int steps;
    public float movementSpeed;
    public NetworkVariable<bool> isMoving = new NetworkVariable<bool>();

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        currentRoute = GameObject.Find("Route").GetComponent<Route>();
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
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (transform.position != nextPos)
            {
                MoveServerRpc(nextPos);

                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
            steps--;
            
        }
        IsNotMovingServerRpc();
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
