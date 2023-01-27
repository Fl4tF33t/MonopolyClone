using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    Route routeData;
    Renderer ren;

    // Specifying the Node data
    public int currentNodeNumber;
    public SOCitiesProperties currentNode;

    void Start()
    {
        routeData = GetComponentInParent<Route>();
        ren = GetComponent<Renderer>();
    }

    //creating private list of SO to node position  
    public void SettingCurrentNode()
    {
        SOCitiesProperties[] possibleCityProperty = routeData.soCitiesProperties;

        for (int i = 0; i < possibleCityProperty.Length; i++)
        {
            if (currentNodeNumber == possibleCityProperty[i].nodeNumber)
            {
                currentNode = possibleCityProperty[i];
                break;
            }
        }
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
