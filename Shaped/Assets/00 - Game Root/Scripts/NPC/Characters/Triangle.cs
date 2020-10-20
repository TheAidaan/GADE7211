using UnityEngine;

public class Triangle : NPC
{
    void Start()
    {
        AssignAttributes("Triangle", "TRIANGLE01",0.1f);


        int speed  = Random.Range(10, 13);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
