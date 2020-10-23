public struct InventoryItem // structor for all Inventory items
{
    public InventoryItem(int Key,  string Name, int IconID)
    {
        key = Key; //for hash

        name = Name;
        iconID = IconID;
    }
    public int key { get; } // the key relating to the hash index
    public string name { get; } // the name of the item
    public int iconID { get; } // where on the sprite array is the icon?

}

public class ItemLibrary //all the inventory items
{
    public static InventoryItem Lines = new InventoryItem(0, "Lines", 5);   //"lines" == the in-game currency 
    public static InventoryItem Neon = new InventoryItem(1, "Neon", 6);   //"Neon" == the in-game flowers 

    //public static InventoryItem Triangle = new InventoryItem(2,"Triangle", "Triangle");
}
