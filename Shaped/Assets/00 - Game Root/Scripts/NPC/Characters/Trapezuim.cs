using UnityEngine;

public class Trapezuim : NPC
{
    void Start()
    {
        AssignAttributes("Trapezuim", 0.05f, 1,true);


        int speed  = Random.Range(13, 18);
        AssignSpeed(speed);
    }
}
