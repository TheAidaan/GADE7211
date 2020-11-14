using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : NPC
{
    void Start()
    {
        AssignAttributes("Angle", 1, 0.07f, 3,false);


        int speed = Random.Range(10, 13);
        AssignSpeed(speed);
    }
}
