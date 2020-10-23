using UnityEngine;

public class Hexagon : NPC
{
    void Start()
    {
        AssignAttributes("Hexagon",1,0.08f,1);

        int speed = Random.Range(7, 10);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }

}
