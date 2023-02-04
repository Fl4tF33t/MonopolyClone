using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Nodes", order = 1)]
public class SONodes : ScriptableObject
{
    public int nodeNumber;
    public string nodeName;
    public Color nodeColor;
    
    public int nodePrice;
    public enum Types { CitiesProperties, Corner, Utilities, Airports, CommunityCards, ChanceCards, Taxes};
    public Types types;

    public bool isOwned = false;
}

