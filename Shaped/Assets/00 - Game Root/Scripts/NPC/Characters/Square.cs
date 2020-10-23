using UnityEngine;

public class Square : NPC
{
    void Start()
    {
        AssignAttributes("Square",3,0.04f,2);


        int speed  = Random.Range(12, 15);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
