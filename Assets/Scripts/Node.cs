using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Node : NetworkBehaviour
{
    Route routeData;
    Renderer ren;
    UIManager uiManager;

    // Specifying the Node data
    public int currentNodeNumber;

    public NetworkVariable<SONodes> currentNode = new NetworkVariable<SONodes>();

    void Start()
    {
        routeData = GetComponentInParent<Route>();
        ren = GetComponent<Renderer>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    //creating private list of SO to node position  
    public void SettingCurrentNode()
    {
        foreach (SONodes soNodes in routeData.soNodes.Value)
        {
            if (currentNodeNumber == soNodes.nodeNumber)
            {
<<<<<<< Updated upstream
                currentNode = routeData.soNodes[i];
                return;
=======
                if (soNodes != null)
                {
                    currentNode.Value = soNodes;

                }
>>>>>>> Stashed changes
            }
        }
    }

    public void SettingNodeData()
    {
        if (currentNode.Value != null)
        {
            ren.material.color = currentNode.Value.nodeColor;
        }
        
    }

    public void ShowNodeData(SONodes currentNode)
    {
        uiManager.nodeName.text = "Welcome to " + currentNode.nodeName;
        if(currentNode.isOwned == true)
        {
            uiManager.nodeOwnership.text = "This property is already owned";
        }else if (currentNode.isOwned == false)
        {
            uiManager.nodeOwnership.text = "This property is available";
        }
        uiManager.nodePrice.text = currentNode.nodeName + " costs " + currentNode.nodePrice + " euros!";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
