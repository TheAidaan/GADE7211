using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elli : NPC
{
    void Start()
    {
        AssignAttributes("Elli", 0.12f, 0, false);

        int speed = Random.Range(8, 11);
        AssignSpeed(speed);
        GameManager.instance.PickNeons += RunAway;
    }

    void RunAway()
    {
        Vector3 target = new Vector3(-110, 0, 230);//runs away
        gameObject.layer = LayerMask.NameToLayer("Default");// not willing to speak anymore
        GetComponentInParent<NPCController>().AssignTarget(target);

        GameManager.instance.PickNeons -= RunAway;
    }
}

