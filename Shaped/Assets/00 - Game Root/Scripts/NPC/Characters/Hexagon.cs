using UnityEngine;

public class Hexagon : NPC
{
    void Start()
    {
        AssignAttributes("Hexagon",0.08f,1,true);

        int speed = Random.Range(7, 10);
        AssignSpeed(speed);
    }

}
