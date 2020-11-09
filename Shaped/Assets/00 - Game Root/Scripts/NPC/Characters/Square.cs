using UnityEngine;

public class Square : NPC
{
    void Start()
    {
        AssignAttributes("Square",4,0.04f,2);


        int speed  = Random.Range(12, 15);
        AssignSpeed(speed);
    }
}
