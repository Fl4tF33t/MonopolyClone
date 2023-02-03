using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Route routeData;
    Renderer ren;

    // Specifying the Node data
    public int currentNodeNumber;

    public SONodes currentNode;

    void Start()
    {
        routeData = GetComponentInParent<Route>();
        ren = GetComponent<Renderer>();
    }

    //creating private list of SO to node position  
    public void SettingCurrentNode()
    {
        /*for (int i = 0; i < routeData.soNodes.Length; i++)
        {
            if (currentNodeNumber == routeData.soNodes[i].nodeNumber)
            {
                currentNode = routeData.soNodes[i];
                return;
            }
        }*/
    }

    public void SettingNodeData()
    {
        if (currentNode != null)
        {
            ren.material.color = currentNode.nodeColor;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
