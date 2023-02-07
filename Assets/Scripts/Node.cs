using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Node : NetworkBehaviour
{
    CSVReader csvReader;
    Route route;
    Renderer ren;

    Color color;
    public NetworkVariable<Color> networkColor = new NetworkVariable<Color>();

    // Specifying the Node data
    public int currentNodeNumber;

    //public SONodes currentNode;
    public NetworkVariable<TestStruct.NetworkNodeData> currentNodeData = new NetworkVariable<TestStruct.NetworkNodeData>();


    private void Awake()
    {
        csvReader = GetComponentInParent<CSVReader>();
        //csvReader.OnNodeDataFinishBuild += SettingCurrentNode;
        route = GetComponentInParent<Route>();
    }
    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    //creating private list of SO to node position  
    public void SettingCurrentNode()
    {
        foreach (CSVReader.NodeData nodeData in csvReader.nodeDataArray) 
        {
            if(nodeData.nodeNumber == currentNodeNumber)
            {
                //currentNodeData.Value = new Route.NetworkNodeData {nodeName = "hi"};
                currentNodeData.Value = new TestStruct.NetworkNodeData { nodeName = nodeData.nodeName };
                return;
            }
        }
    }

    public void SettingNodeData()
    {
        /* if (ColorUtility.TryParseHtmlString(currentNodeData.Value.nodeColor, out color))
         {
             networkColor.Value = color;
             ren.material.color = networkColor.Value;
         }*/
        return;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
