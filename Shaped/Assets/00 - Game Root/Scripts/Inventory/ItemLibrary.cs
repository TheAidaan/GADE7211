public struct InventoryItem // structor for all Inventory items
{
    public InventoryItem(int Key,  string Name, string File)
    {
        key = Key; //for hash

        name = Name;
        file = File;
    }
    public int key { get; } // the key relating to the hash index
    public string name { get; } // the name of the item
    public string file { get; } // the path for the display icon
}

public class ItemLibrary //all the inventory items
{
    public static InventoryItem Circle = new InventoryItem(4,"Circle", "Circle");
    public static InventoryItem Hexagon = new InventoryItem(11,"Hexagon", "Hexagon");
    public static InventoryItem Triangle = new InventoryItem(2,"Triangle", "Triangle");
}
