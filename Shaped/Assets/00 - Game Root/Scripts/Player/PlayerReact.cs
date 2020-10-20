using UnityEngine;

public class PlayerReact : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item!= null)
        {
            PlayerInventory.Add(item.GetItem());
            Destroy(collision.gameObject);
        }
    }
}
