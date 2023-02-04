using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
    }
=======
        currentPlayers.Add(Convert.ToInt32(player));
    }
    private void DisconnectedPlayers(ulong player)
    {
        currentPlayers.Remove(Convert.ToInt32(player));
    }


>>>>>>> Stashed changes
}
