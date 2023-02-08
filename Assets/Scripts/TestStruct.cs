using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class TestStruct : NetworkBehaviour
{
    public TextAsset csvFile;
    public NetworkNodeData[] nodeDataArray;

    public enum NodeType { Corner, City, Community, Taxes, Airport, Chance, Utility }

    [System.Serializable]
    public struct NetworkNodeData : INetworkSerializable
    {
        public int nodeNumber;
        public string nodeName;
        public bool isPurchasable;
        public int nodeBuyPrice;
        public int nodeSellPrice;
        public bool isOwned;
        public string nodeColor;

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
    }

    void ReadCSV()
    {
        string[] data = csvFile.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);
        int columns = 8;

        int tableSize = data.Length / columns - 1;
        nodeDataArray = new NetworkNodeData[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            nodeDataArray[i] = new NetworkNodeData();
            nodeDataArray[i].nodeNumber = int.Parse(data[columns * (i + 1)]);
            nodeDataArray[i].nodeName = data[columns * (i + 1) + 1];
            nodeDataArray[i].isPurchasable = bool.Parse(data[columns * (i + 1) + 2]);
            nodeDataArray[i].nodeBuyPrice = int.Parse(data[columns * (i + 1) + 3]);
            nodeDataArray[i].nodeSellPrice = int.Parse(data[columns * (i + 1) + 4]);
            nodeDataArray[i].isOwned = bool.Parse(data[columns * (i + 1) + 5]);
            nodeDataArray[i].nodeColor = (data[columns * (i + 1) + 6]);
            nodeDataArray[i].nodeType = (NodeType)Enum.Parse(typeof(NodeType), data[columns * (i + 1) + 7]);
        }
       // OnNodeDataFinishBuild?.Invoke();
    }

    public NetworkVariable<NetworkNodeData> nodedata = new NetworkVariable<NetworkNodeData>();
    private void Start()
    {
        ReadCSV();
    }
}
