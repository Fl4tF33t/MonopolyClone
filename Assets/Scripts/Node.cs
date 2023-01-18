using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //all possible NodeData
    public SOCitiesProperties[] nodeData;
    public List<int> nodeDataNumber = new List<int>();

    Route routeData;

    // Specifying the Node data
    public int currentNodeNumber;
    public SOCitiesProperties currentNode;

    void Start()
    {
        routeData = GetComponentInParent<Route>();

        //creating private list of SO to node position   
        for (int i = 0; i < nodeData.Length; i++)
        {
            nodeDataNumber.Add(nodeData[i].nodeNumber);
        }
        
    }

    //creating private list of SO to node position  
    public void TileSpawn()
    {
        for (int i = 0; i < nodeDataNumber.Count; i++)
        {
            if (nodeDataNumber[i] == currentNodeNumber)
            {
                currentNode = nodeData[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
