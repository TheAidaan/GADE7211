using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : NPC
{
    void Start()
    {
        AssignAttributes("Hex", 1, 0.08f, 1, false);

        int speed = Random.Range(7, 10);
        AssignSpeed(speed);
    }

}
