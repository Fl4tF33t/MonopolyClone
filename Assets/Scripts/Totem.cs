using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Totem : NetworkBehaviour
{
    public Route currentRoute;
    public int routePosition;

    public int steps;
    public float movementSpeed;
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        currentRoute = GameObject.Find("Route").GetComponent<Route>();
    }

    // Update is called once per frame
    void Update()
    {
        //basic imput system
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 7);
            StartCoroutine(Move());
        }
    }

    //Movement of the totem
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

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

        isMoving = false;
        
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
