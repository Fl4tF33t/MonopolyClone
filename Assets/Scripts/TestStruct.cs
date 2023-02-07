using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TestStruct : NetworkBehaviour
{
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
    }

    public NetworkVariable<NetworkNodeData> nodedata = new NetworkVariable<NetworkNodeData>();
}
