using UnityEngine;

public class Hexagon : NPC
{
    void Start()
    {
        AssignAttributes("Hexagon", "Hexagon01", 0.1f);

        int speed = Random.Range(7, 10);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }

}
