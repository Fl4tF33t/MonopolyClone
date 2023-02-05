using UnityEngine;
using System.Collections;
using System;

public class CSVReader : MonoBehaviour
{
    //This script is used to extract data from the CSVfile set it into usable arrays

	public TextAsset csvFile;
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
        public int nodeType;
    }

    [System.Serializable]
    public class NodeDataList
    {
        public NodeData[] nodeDataArray;
    }

    public NodeDataList myNodeDattaArray = new NodeDataList();

    void ReadCSV()
    {
        string[] data = csvFile.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int columns = 8;

        int tableSize = data.Length / columns - 1;
        myNodeDattaArray.nodeDataArray = new NodeData[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myNodeDattaArray.nodeDataArray[i] = new NodeData();
            myNodeDattaArray.nodeDataArray[i].nodeNumber = int.Parse(data[columns * (i + 1)]);
            myNodeDattaArray.nodeDataArray[i].nodeName = data[columns * (i + 1) + 1];
            myNodeDattaArray.nodeDataArray[i].isPurchasable = bool.Parse(data[columns * (i + 1) + 2]);
            myNodeDattaArray.nodeDataArray[i].nodeBuyPrice = int.Parse(data[columns * (i + 1) +  3]);
            myNodeDattaArray.nodeDataArray[i].nodeSellPrice = int.Parse(data[columns * (i + 1) + 4]);
            myNodeDattaArray.nodeDataArray[i].isOwned = bool.Parse(data[columns * (i + 1) + 5]);
            myNodeDattaArray.nodeDataArray[i].nodeColor = (data[columns * (i + 1) + 6]);
            myNodeDattaArray.nodeDataArray[i].nodeType = int.Parse(data[columns * (i + 1) + 4]);
        }
        OnNodeDataFinishBuild?.Invoke();
    }

    private void Start()
    {
        ReadCSV();
    }
}