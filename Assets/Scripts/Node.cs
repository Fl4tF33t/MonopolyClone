using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //all possible NodeData
    public SOCitiesProperties[] nodeData;
    public List<int> nodeDataNumber = new List<int>();

    Renderer ren;

    // Specifying the Node data
    public int currentNodeNumber;
    public SOCitiesProperties currentNode;
    public SOCitiesProperties testNode;

    void Start()
    {
        //creating private list of SO to node position   
        for (int i = 0; i < nodeData.Length; i++)
        {
            nodeDataNumber.Add(nodeData[i].nodeNumber);
        }
        ren = GetComponent<Renderer>();
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

    public void SettingNodeData()
    {
        if (currentNode == null)
        {
            ren.material.color = testNode.nodeColor;
        }
        else
        {
            ren.material.color = currentNode.nodeColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
