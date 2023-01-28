using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class TextBillBoard : NetworkBehaviour
{
    Totem totem;
    TextMeshPro text;

    private void Start()
    {
        totem = transform.parent.GetComponent<Totem>();
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;

        if (totem.isMoving.Value)
        {
            text.text = "Moving";
        }
        else
        {
            text.text = "Not Moving";
        }
    }
}
