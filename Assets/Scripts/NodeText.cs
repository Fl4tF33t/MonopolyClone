using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeText : MonoBehaviour
{
    TextMeshPro text;
    Node nodeInfo;
    // Start is called before the first frame update
    void Start()
    {
        nodeInfo = GetComponentInParent<Node>();
        text = GetComponent<TextMeshPro>();
        text.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText(SONodes soNode)
    {
        if(soNode == nodeInfo.currentNode)
        {
            text.text = "You are currently on " + soNode.nodeName;
        }
    }
}
