using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            Destroy(other.gameObject.transform.parent.parent.gameObject);//the body is a child of the sprite which is a child of the complete NPC that must be destroyed
            Spawner.Static_DecreaseNumeberOFNPCs();
        }
    }
            
}
