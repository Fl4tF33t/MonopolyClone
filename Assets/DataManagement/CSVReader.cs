using UnityEngine;
using System.Collections;
using System;

public class CSVReader : MonoBehaviour
{
    //This script is used to extract data from the CSVfile set it into usable arrays
    //The data is set as non-network and later transfered into a network struct in RouteClass
    //The array is 
    //Can try to directly change into a network struct, but not until a working version is made
    //until then, dont edit this class

	public TextAsset csvFile;
    public NodeData[] nodeDataArray;

    public enum NodeType {Corner, City, Community, Taxes, Airport, Chance, Utility}
    public event Action OnNodeDataFinishBuild;

    [System.Serializable]
    public class NodeData 
    {
        public int nodeNumber;
        public string nodeName;
        public bool isPurchasable;
        public int nodeBuyPrice;
        public int nodeSellPrice;
        public bool isOwned;
        public string nodeColor;
        public NodeType nodeType;
    }

    //public NodeDataList myNodeDattaArray = new NodeDataList();

    void ReadCSV()
    {
        string[] data = csvFile.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);
        int columns = 8;

        int tableSize = data.Length / columns - 1;
        nodeDataArray = new NodeData[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            nodeDataArray[i] = new NodeData();
            nodeDataArray[i].nodeNumber = int.Parse(data[columns * (i + 1)]);
            nodeDataArray[i].nodeName = data[columns * (i + 1) + 1];
            nodeDataArray[i].isPurchasable = bool.Parse(data[columns * (i + 1) + 2]);
            nodeDataArray[i].nodeBuyPrice = int.Parse(data[columns * (i + 1) +  3]);
            nodeDataArray[i].nodeSellPrice = int.Parse(data[columns * (i + 1) + 4]);
            nodeDataArray[i].isOwned = bool.Parse(data[columns * (i + 1) + 5]);
            nodeDataArray[i].nodeColor = (data[columns * (i + 1) + 6]);
            nodeDataArray[i].nodeType = (NodeType)Enum.Parse(typeof(NodeType), data[columns * (i + 1) + 7]);
        }
        OnNodeDataFinishBuild?.Invoke();
    }
    private void Start()
    {
        ReadCSV();

    }
}