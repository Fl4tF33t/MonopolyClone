using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stops", order = 1)]
public class ScriptableObjectSpots : ScriptableObject
{
    public string stopName;
    public Color stopColor;
    public int stopNumber;
    

    public int stopPrice;
    public int mortgagePrice;
    public int housePrice;
    public int hotelPrice;

    public int numberOfHouses;
    public int numberOfHotels;

    public int rentPrice;
}

