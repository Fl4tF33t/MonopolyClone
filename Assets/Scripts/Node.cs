using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Node : NetworkBehaviour
{
    CSVReader csvReader;
    Renderer ren;

    Color color;
    public NetworkVariable<Color> networkColor = new NetworkVariable<Color>();

    // Specifying the Node data
    public int currentNodeNumber;

    //public SONodes currentNode;
    public NetworkVariable<CSVReader.NodeData> currentNodeData;

    void Start()
    {
        csvReader = GetComponentInParent<CSVReader>();
        ren = GetComponent<Renderer>();
    }

    //creating private list of SO to node position  
    
    public void SettingCurrentNode()
    {
        foreach (CSVReader.NodeData nodeData in csvReader.myNodeDattaArray.nodeDataArray)
        {
            if(nodeData.nodeNumber == currentNodeNumber)
            {
                currentNodeData.Value = nodeData;
            }
        }
    }
    public void SettingNodeData()
    {
        if (ColorUtility.TryParseHtmlString(currentNodeData.Value.nodeColor, out color))
        {
             
            ren.material.color = color;

        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
