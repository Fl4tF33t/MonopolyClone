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

    private void Awake()
    {
        csvReader = GetComponent<CSVReader>();
        //csvReader.OnNodeDataFinishBuild += CreateChildrenNodeListData;
    }
    private void Start()
    {
        CreateChildrenNodeListData();
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
                //node.SettingCurrentNode();
                nodeNumber++;
            }        
        }
    }

    /*public struct NetworkNodeData : INetworkSerializable
    {
        public int nodeNumber;
        public string nodeName;
        public bool isPurchasable;
        public int nodeBuyPrice;
        public int nodeSellPrice;
        public bool isOwned;
        public string nodeColor;
        
        public enum NodeType { Corner, City, Community, Taxes, Airport, Chance, Utility }
        public NodeType nodeType;
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref nodeNumber);
            serializer.SerializeValue(ref nodeName);
            serializer.SerializeValue(ref isPurchasable);
            serializer.SerializeValue(ref nodeBuyPrice);
            serializer.SerializeValue(ref nodeSellPrice);
            serializer.SerializeValue(ref isOwned);
            serializer.SerializeValue(ref nodeColor);
            serializer.SerializeValue(ref nodeType);
        }
    }*/
}
