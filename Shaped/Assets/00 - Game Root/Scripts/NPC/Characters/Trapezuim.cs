using UnityEngine;

public class Trapezuim : NPC
{
    void Start()
    {
        AssignAttributes("Trapezium", 2, 0.05f, 1);


        int speed  = Random.Range(13, 18);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
