using UnityEngine;

public class Triangle : NPC
{
    void Start()
    {
        AssignAttributes("Triangle",0.07f,3,true);


        int speed  = Random.Range(10, 13);
       AssignSpeed(speed);
    }
}
