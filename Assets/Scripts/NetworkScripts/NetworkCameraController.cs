using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkCameraController : NetworkBehaviour
{
    float speed = 200f;
    GameObject board;
    Vector3 focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board");
        focalPoint = board.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (IsOwner)
        {
            //zooming in and out
            float zoomLimit = transform.localPosition.z;
            if (zoomLimit >= -25 && zoomLimit <= -6)
            {
                float zoomScroll = Input.GetAxis("Mouse ScrollWheel");
                Vector3 directionalMagnitude = transform.position - focalPoint;
                transform.position += directionalMagnitude * -zoomScroll * Time.deltaTime * speed; 
            }

            //panning around
            if (Input.GetKey(KeyCode.Mouse1))
            {
                //panning
                float horizontalPanning = Input.GetAxis("Mouse X");
                transform.RotateAround(focalPoint, Vector3.up, horizontalPanning);
            }   

        }
    }
}
