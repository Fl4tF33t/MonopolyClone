using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    public Route currentRoute;
    public int routePosition;

    public int steps;
    public float movementSpeed;
    bool isMoving;


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
            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
            steps--;
            
        }

        isMoving = false;
        
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, movementSpeed * Time.deltaTime));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
