using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Linq;

namespace SecondAttempt
{
    public class RouteSecond : NetworkBehaviour
    {
        DataStruct_Cards networkStruct;
        public List<Transform> childTransforms;

        private void Awake()
        {
            networkStruct = GetComponent<DataStruct_Cards>();

            networkStruct.finishedEvent.AddListener(AddDataToChildren);

            AddChildrenToList();
            //AddDataToChildren();
        }

        void AddChildrenToList()
        {
            childTransforms = GetComponentsInChildren<Transform>().ToList<Transform>();
            childTransforms.Remove(childTransforms.First());
        }

        //Invoked when networkStruct.finishedEvent is heard.
        public void AddDataToChildren()
        {
            for (int i = 0; i < childTransforms.Count; i++)
            {
                //Add nodes their count
                NodeSecond node = childTransforms[i].GetComponent<NodeSecond>();
                node.currentNodeNumber = i;
                Debug.Log(networkStruct.nodeDataArray.Length + " StructLength");
                Debug.Log(childTransforms.Count + " transformsCount");

                node.currentNodeData.Value = new DataStruct_Cards.NetworkNodeData
                {
                    nodeNumber = networkStruct.nodeDataArray[i].nodeNumber,
                    nodeName = networkStruct.nodeDataArray[i].nodeName,
                    isPurchasable = networkStruct.nodeDataArray[i].isPurchasable,
                    nodeBuyPrice = networkStruct.nodeDataArray[i].nodeBuyPrice,
                    nodeSellPrice = networkStruct.nodeDataArray[i].nodeSellPrice,
                    isOwned = networkStruct.nodeDataArray[i].isOwned,
                    nodeColor = networkStruct.nodeDataArray[i].nodeColor,
                    nodeType = networkStruct.nodeDataArray[i].nodeType
                };
            }
        }
    } 
}
