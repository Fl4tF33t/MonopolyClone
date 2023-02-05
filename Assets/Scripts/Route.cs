using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Route : NetworkBehaviour
{
    CSVReader csvData;
    Transform[] childObjects;
    Node[] childNode;
    public List<Transform> childNodeList = new List<Transform>();
    //public SONodes[] soNodes;
    

    private void Start()
    {
        csvData = GetComponent<CSVReader>();
        CreateChildrenNodeList();
        NetworkManager.Singleton.OnServerStarted += SetEachNodeData;
        NetworkManager.Singleton.OnClientConnectedCallback += Redo; 
    }

    //This is for the editor view, so that we can see what path the totem is taking, can be romed later
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
    private void CreateChildrenNodeList()
    {
        childNodeList.Clear(); 
        childObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);            
            }        
        }
        
    }
    void Redo(ulong u) { SetEachNodeData(); }


    //Referencing each node to have its own properties
    public void SetEachNodeData()
    {
        childNode = GetComponentsInChildren<Node>();
        for (int i = 0; i < childNode.Length; i++)
        {
            childNode[i].currentNodeNumber = i;
            childNode[i].SettingCurrentNode();
            childNode[i].SettingNodeData();
        }
    }

}
