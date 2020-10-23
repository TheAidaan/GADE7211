using UnityEngine;

public class Triangle : NPC
{
    void Start()
    {
        AssignAttributes("Triangle",1,0.07f,3);


        int speed  = Random.Range(10, 13);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
