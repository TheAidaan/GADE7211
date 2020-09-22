using System;
using System.Diagnostics;

public class HashData
{
    public InventoryItem data;
    public int key;

    public HashData(int Key, InventoryItem Data) // KEY then DATA
    {
        this.key = Key;
        this.data = Data;
    }
}
public class HashTable
{
    int _itemsInArray = 0; // to count whether the array is full or not
    const int ARRAY_SIZE = 6; //inventory will hold 6 items...

    HashData[] _hashtable = new HashData[ARRAY_SIZE];//... x

    public bool Add(InventoryItem inventoryItem) //KEY then DATA
    {
        if (_itemsInArray == ARRAY_SIZE)
        {
            return false; //dont even try if the array is full
        }

        for (int i = 0; i < ARRAY_SIZE; i++) // look for empty space (prevents collisons)
        {
            int index = (HashCode(inventoryItem.key) + i) % ARRAY_SIZE; // first checks original hashcode then moves on 

            if (_hashtable[index] == null) // found an empty spot
            {
                HashData hashItem = new HashData(inventoryItem.key, inventoryItem);
                _hashtable[index] = hashItem; // added

                _itemsInArray++; // increase counter

                return true;//stop looping when added
            }
        }
        return false;
    }

    public void Delete(HashData delete)
    {

        for (int i = 0; i < ARRAY_SIZE; i++) // to find an empty spot
        {
            int index = (HashCode(delete.key) + i) % ARRAY_SIZE; // first checks original hashcode then moves on 

            if ((_hashtable[index] != null) && (_hashtable[index].key == delete.key)) // found it 
            {
                _hashtable[index] = null; // mark as deleted 
            }
        }
    }

    public HashData Search(int key)
    {

        for (int i = 0; i < ARRAY_SIZE; i++) // go through all entries
        {
            int index = (HashCode(key) + i) % ARRAY_SIZE; // first checks original hashcode then moves on 

            if ((_hashtable[index] != null) && (_hashtable[index].key == key)) //found
            {
                return _hashtable[index]; //send it
            }
        }

        return null;
    }

    public HashData[] Display()
    {
        return _hashtable;
    }

    public int HashCode(int key)
    {
        return key % ARRAY_SIZE;
    }

}


