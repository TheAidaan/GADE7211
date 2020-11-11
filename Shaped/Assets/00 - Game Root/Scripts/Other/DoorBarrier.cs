using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBarrier : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            collision.gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }
}
