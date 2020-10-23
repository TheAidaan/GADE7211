using UnityEngine;

public class Circle : NPC
{
   
    void Start()
    {
        AssignAttributes("Circle", 0.12f, 0);

        int speed = Random.Range(8, 11);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
