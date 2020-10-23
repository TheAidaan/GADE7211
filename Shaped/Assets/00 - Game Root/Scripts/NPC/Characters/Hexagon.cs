using UnityEngine;

public class Hexagon : NPC
{
    void Start()
    {
        numberOfDialogueFiles = 1;
        AssignAttributes("Hexagon", 0.08f,1);

        int speed = Random.Range(7, 10);
        GetComponentInParent<NPCcontroller>().AssignSpeed(speed);
    }

}
