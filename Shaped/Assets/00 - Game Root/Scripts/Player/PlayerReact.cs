using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReact : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item!= null)
        {
            PlayerInventory.Add(item.GetItem());
            Destroy(collision.gameObject);
        }
    }
}
