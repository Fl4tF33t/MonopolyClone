using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Cards", order = 2)]
public class ScriptableObjectsCards : ScriptableObject
{
    public string stopName;
    public Color stopColor;
    public int stopNumber;

    public List<Cards> cardList = new List<Cards>();
    
}