using System.Collections.Generic;
using UnityEngine;

public class PlayerArray : Singleton<PlayerArray>
{
    public List<GameObject> PlayerList;

    // Initialize during Awake if possible.
    void Awake () {
        PlayerList = new List<GameObject>();
    }
}