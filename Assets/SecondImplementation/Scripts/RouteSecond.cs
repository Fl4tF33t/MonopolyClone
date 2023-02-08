using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class RouteSecond : NetworkBehaviour
{
    Transform[] childObjects;

    private void Awake()
    {
        if (!IsServer)
        {
            return;
        }
    }

    
}
