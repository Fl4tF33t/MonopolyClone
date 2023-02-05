using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Route : NetworkBehaviour
{
    //this script is used to set the route path of the nodes, here we can call the nodes to set their data

    CSVReader csvReader;
    Transform[] childObjects;

    public List<Transform> childNodeList = new List<Transform>();
    

    private void Start()
    {
        //calls the function once all the data has been processed and extracted
        csvReader = GetComponent<CSVReader>();
        csvReader.OnNodeDataFinishBuild += CreateChildrenNodeListData;
    }

    //This is for the editor view, so that we can see what path the totem is taking, can be remomed later
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

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

    //adds the transform of each child object to a public childNodeList, this is done because GetComponentsInChildren add the parent to the array at index 0
    private void CreateChildrenNodeListData()
    {
        //Create a public list of all the children
        childNodeList.Clear(); 
        childObjects = GetComponentsInChildren<Transform>();
        int nodeNumber = 0;

        //sets the nodedata for each child
        foreach(Transform child in childObjects)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);

                Node node = child.GetComponent<Node>();
                node.currentNodeNumber = nodeNumber;
                node.SettingCurrentNode();
                node.SettingNodeData();
                nodeNumber++;
            }        
        }
    }
}
