using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Cities & Properties", order = 1)]
public class SOCitiesProperties : ScriptableObject
{
    public int nodeNumber;
    public string nodeName;
    public Color nodeColor;

    public int nodePrice;
}

