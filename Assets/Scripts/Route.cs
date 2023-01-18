using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] childObjects;
    Node[] childNode;
    public List<Transform> childNodeList = new List<Transform>();

    //just draws a line between the nodes and calls the FillNodes Method
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        FillNodes();

        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if (i > 0)
            {
                Vector3 previousPos = childNodeList[i - 1].position;
                Gizmos.DrawLine(previousPos, currentPos);
            }
        }

    }

    //adds the transform of each child object to a public childNodeList
    private void FillNodes()
    {
        childNodeList.Clear();
        
        childObjects = GetComponentsInChildren<Transform>();
        childNode = GetComponentsInChildren<Node>();

        foreach(Transform child in childObjects)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);            
            }        
        }
        for (int i = 0; i < childNode.Length; i++)
        {
            childNode[i].currentNodeNumber = i;
            childNode[i].TileSpawn();
        }
    }

    private void Start()
    {
        FillNodes();
    }
}
