using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //all possible NodeData
    [SerializeField] ScriptableObjectSpots[] nodeData;
    Route routeInfo;

    //specifying the node Data
    public ScriptableObjectSpots currentScriptableObject;

    Renderer nodeRenderer;

    // Specifying the Node data
    void Start()
    {
        routeInfo = GetComponentInParent<Route>();
        nodeRenderer = GetComponent<Renderer>();

        for (int i = 0; i < routeInfo.childNodeList.Count; i++)
        {
            if(this.transform == routeInfo.childNodeList[i].transform)
            {
                currentScriptableObject = nodeData[i];
            }
        }

        nodeRenderer.material.color = currentScriptableObject.stopColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
