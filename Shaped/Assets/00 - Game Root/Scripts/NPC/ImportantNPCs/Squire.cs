using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squire : NPC
{
    void Start()
    {
        AssignAttributes("Squire", 4, 0.04f, 2, false);


        int speed = Random.Range(12, 15);
        AssignSpeed(speed);
    }
}