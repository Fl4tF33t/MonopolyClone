using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform pivotPoint;
    public Totem totemInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition(totemInfo.routePosition);
           
    }
    
    public void CameraPosition(int routePosition)
    {
        switch (routePosition)
        {
            case int n when (n > 0 && n < 11):
                transform.RotateAround(pivotPoint.position, Vector3.up, 0);
                break;
            case int n when (n > 10 && n < 21):
                transform.RotateAround(pivotPoint.position, Vector3.up, 90);
                break;
            case int n when (n > 20 && n < 31):
                transform.RotateAround(pivotPoint.position, Vector3.up, 180);
                break;
            case int n when (n > 30 && n < 40):
                transform.RotateAround(pivotPoint.position, Vector3.up, 270);
                break;
        }
    }
}
