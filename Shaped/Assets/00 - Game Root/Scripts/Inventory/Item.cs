using UnityEngine;

public class Item : MonoBehaviour
{
    InventoryItem _item;

    enum Items
    {
        Lines,
        Neon,
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
            case Items.Lines:
                _item = ItemLibrary.Lines;
                break;
            case Items.Neon:
                _item = ItemLibrary.Neon;
                break;
            
        }
    }

    public InventoryItem GetItem()
    {
        return _item;
    }
}
