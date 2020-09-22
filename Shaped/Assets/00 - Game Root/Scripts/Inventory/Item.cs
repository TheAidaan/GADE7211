using UnityEngine;

public class Item : MonoBehaviour
{
    InventoryItem _item;

    enum Items
    {
        circle,
        hexagon,
        triangle
    }
    [SerializeField] Items item;


    private void Start()
    {
        SetItem();
    }

    void SetItem()
    {
        switch (item)
        {
            default:
            case Items.circle:
                _item = ItemLibrary.Circle;
                break;
            case Items.hexagon:
                _item = ItemLibrary.Hexagon;
                break;
            case Items.triangle:
                _item = ItemLibrary.Triangle;
                break;
        }
    }

    public InventoryItem GetItem()
    {
        return _item;
    }
}
