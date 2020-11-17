using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Are : NPC
{
    void Start()
    {
        AssignAttributes("Are", 0.04f, 2,false);


        int speed = Random.Range(12, 15);
        AssignSpeed(speed);
    }
}