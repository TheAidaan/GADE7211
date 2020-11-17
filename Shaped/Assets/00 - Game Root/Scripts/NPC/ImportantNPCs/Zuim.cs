using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zuim : NPC
{
    void Start()
    {
        AssignAttributes("Zuim", 0.05f, 1, false);


        int speed = Random.Range(13, 18);
        AssignSpeed(speed);
    }
}