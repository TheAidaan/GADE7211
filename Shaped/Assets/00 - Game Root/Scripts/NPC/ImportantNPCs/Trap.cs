using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : NPC
{
    void Start()
    {
        AssignAttributes("Trap", 0.05f, 1, false);


        int speed = Random.Range(13, 18);
        AssignSpeed(speed);
    }
}

