using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Node : NetworkBehaviour
{
    Route routeData;
    CSVReader csvReader;
    Renderer ren;
    Color color;
    public NetworkVariable<Color> networkColor = new NetworkVariable<Color>();

    // Specifying the Node data
    public int currentNodeNumber;

    //public SONodes currentNode;
    public CSVReader.NodeData nodeData;

    void Start()
    {
        routeData = GetComponentInParent<Route>();
        csvReader = GetComponentInParent<CSVReader>();
        ren = GetComponent<Renderer>();
    }

    //creating private list of SO to node position  
    public void SettingCurrentNode()
    {
        for (int i = 0; i < csvReader.myNodeDattaArray.nodeDataArray.Length; i++)
        {
            if (currentNodeNumber == csvReader.myNodeDattaArray.nodeDataArray[i].nodeNumber)
            {
                nodeData = csvReader.myNodeDattaArray.nodeDataArray[i];
            }
        }
    }

    public void SettingNodeData()
    {
        if (ColorUtility.TryParseHtmlString(nodeData.nodeColor, out color))
        {
             
            ren.material.color = color;

        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
