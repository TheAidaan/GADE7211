using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    InventoryItem me;
    [SerializeField] enum Items
    {
        Circle,
        Hexagon,
        Triangle,
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //void Me()
    //{
    //    switch (Items)
    //    {
    //        default:
    //        case Items.Circle:
    //            me = InventoryItems.Circle;
    //            break;
    //        case Items.Hexagon:
    //            me = InventoryItems.Hexagon;
    //            break;
    //        case Items.Triangle:
    //            me = InventoryItems.Triangle;
    //            break;
    //    }
    //}
}
