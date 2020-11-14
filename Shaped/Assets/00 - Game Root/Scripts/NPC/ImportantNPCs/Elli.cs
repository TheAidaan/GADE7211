using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elli : NPC
{
    void Start()
    {
        AssignAttributes("Elli", 1, 0.12f, 0, false);

        int speed = Random.Range(8, 11);
        AssignSpeed(speed);
    }
}

