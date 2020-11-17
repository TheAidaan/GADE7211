using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tria : NPC
{
    void Start()
    {
        AssignAttributes("Tria", 0.05f, 1, false);


        int speed = Random.Range(10, 13);
        AssignSpeed(speed);
    }
}
