using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Totem : NetworkBehaviour
{
    public Route currentRoute;
    public int routePosition;

    PlayerController playerControllerInfo;

    public int steps;
    public float movementSpeed;
    public NetworkVariable<bool> isMoving = new NetworkVariable<bool>();

    // Start is called before the first frame update
    void Start()
    {
        currentRoute = GameObject.Find("Route").GetComponent<Route>();
        playerControllerInfo = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        //We don't want/can't other except the owner to access ServerRpc
        if (!IsOwner)
        {
            return;
        }

        //basic imput system
       /* if (Input.GetKeyDown(KeyCode.Space) && !isMoving.Value == true)
        {
            steps = Random.Range(1, 7);
            StartCoroutine(Move());
        }*/
    }

    //Movement of the totem
    public IEnumerator Move()
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
                moveServerRpc(nextPos);

                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
            steps--;
            
        }

        IsNotMovingServerRpc();
        playerControllerInfo.EndOfTurn();
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
    void moveServerRpc(Vector3 goal)
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime);
    }

    
    /*
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime));
    }
    */
}
