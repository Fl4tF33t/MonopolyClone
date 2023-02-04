using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    Totem totem;

    int diceNumber1;
    int diceNumber2;

    public event Action<int> OnDiceRoll;

    // Start is called before the first frame update
    void Start()
    {
        totem = GetComponent<Totem>();
    }

    // Update is called once per frame
    void Update()
    {
        DiceRoll();
    }

    //player's input system
    void DiceRoll()
    {
        if (IsOwner)
        {
            if (Input.GetKeyDown(KeyCode.Space) && totem.isMoving.Value == false)
            {
                diceNumber1 = UnityEngine.Random.Range(1, 7);
                diceNumber2 = UnityEngine.Random.Range(1, 7);
                OnDiceRoll?.Invoke(diceNumber1 + diceNumber2);
            };
        }
    }
}
