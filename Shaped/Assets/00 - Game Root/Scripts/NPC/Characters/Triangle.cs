using UnityEngine;

public class Triangle : NPC
{
    void Start()
    {
        numberOfDialogueFiles = 1;
        AssignAttributes("Triangle",0.1f,3);


        int speed  = Random.Range(10, 13);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
