using UnityEngine;

public class Circle : NPC
{
   
    void Start()
    {
        AssignAttributes("Circle", "CICRLE01", 0.12f);

        int speed = Random.Range(8, 11);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
