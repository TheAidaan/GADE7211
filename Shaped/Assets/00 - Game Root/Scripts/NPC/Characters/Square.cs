using UnityEngine;

public class Square : NPC
{
    void Start()
    {
        numberOfDialogueFiles = 2;
        AssignAttributes("Square",0.04f,2);


        int speed  = Random.Range(12, 15);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }
}
