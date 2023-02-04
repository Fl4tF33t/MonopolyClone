using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


class MyClass : NetworkBehaviour
{
    public int f;

    public struct NetworkNodeDataStruct : INetworkSerializable
    {
        public int nodeNumber;
        public string nodeName;
        public Color nodeColor;



        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref nodeNumber);
            serializer.SerializeValue(ref nodeName);

            serializer.SerializeValue(ref nodeColor);

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(f);
        }
    }

    [ServerRpc]
    public void SetDataServerRpc(NetworkNodeDataStruct myStruct)
    {
        myStruct = new NetworkNodeDataStruct { };
        myStruct.nodeNumber = f; 
    }
}

