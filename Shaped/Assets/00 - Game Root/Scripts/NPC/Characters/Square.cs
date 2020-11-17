using UnityEngine;

public class Square : NPC
{
    void Start()
    {
        AssignAttributes("Square",0.04f,2,true);


        int speed  = Random.Range(12, 15);
        AssignSpeed(speed);
    }
}
