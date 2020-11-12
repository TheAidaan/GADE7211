using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    const int NUMBER_OF_ITEM_SLOTS = 4;
    public static HashTable<InventoryItem> inventory = new HashTable<InventoryItem>(); //the player inventory

    ItemSlot[] _itemSlots = new ItemSlot[NUMBER_OF_ITEM_SLOTS];//to hold all itemSlots

    static PlayerInventory instance;//single...
    private void Awake()
    {
        instance = this; //..ton
    }
    void Start()
    { 
        for (int i = 0; i < NUMBER_OF_ITEM_SLOTS; i++)
        {
            _itemSlots[i] = transform.GetChild(i).gameObject.GetComponent<ItemSlot>(); // gather all item slots
        }

        DisplayItems();
    }

    void DisplayItems()
    {
        HashData<InventoryItem>[] displayItems = inventory.Display(); // length should always be the amount of items in the hashtable

        int x = 0; // to present the items from top to bottom

        for(int i=0;i< displayItems.Length; i++)
        {
            if (displayItems[i] != null) // only show the stored items in the array, fuck the nulls
            {
                _itemSlots[x].SetItem(displayItems[i].data); // show the item on screen
                x++; //only if item is added, can the next itemslot be used
            }
        }

        HideUnusedSlots(x);
    }

    void HideUnusedSlots(int index) // class will hide all the unused Slots
    {
        if (index < _itemSlots.Length)// if all slots are filled then there are not unused slots to hide
        {
            while (index < _itemSlots.Length)
            {
                _itemSlots[index].DestroyItem();
                index++;
            }
        }
    }
    void HideAllSlots()
    {
        for (int i = 0; i < NUMBER_OF_ITEM_SLOTS; i++)
        {
            _itemSlots[i].SlideOut();
            Debug.Log("hidden");
        }
    }

    /*              PUBLIC STATICS              */

    public static void Add(InventoryItem item) // anything can add an item to the inventory
    {
        bool added =  inventory.Add(item.key, item); // the add, might be successful, might not 

        if (added)
        {
            instance.DisplayItems();
        }
        else
        {
            Debug.Log("Item not added");
        }
    }

    public static void Delete(InventoryItem item) // anything can add an item to the inventory
    {
        bool deleted = inventory.Delete(item.key); // the add, might be successful, might not 

        if (deleted)
            if (!DialogueManager.activeDialogue)
                instance.DisplayItems();
        else
            Debug.Log("Item not deleted");
        
    }

    public static void Static_HideAllSlots()
    {
        instance.HideAllSlots();
    }
    public static void Static_DisplayItems()
    {
        instance.DisplayItems();
    }

}
