public class HashData<T>
{
    public T data;
    public int key;

    public HashData(int Key, T Data) // KEY then DATA
    {
        this.key = Key;
        this.data = Data;
    }
}
public class HashTable<T>
{
    int _itemsInArray = 0; // to count whether the array is full or not
    const int ARRAY_SIZE = 6; //inventory will hold 6 items...

    HashData<T>[] _hashtable = new HashData<T>[ARRAY_SIZE];//... x

    public bool Add(int key,T inventoryItem) //KEY then DATA
    {
        if (_itemsInArray == ARRAY_SIZE)
        {
            return false; //dont even try if the array is full
        }

        for (int i = 0; i < ARRAY_SIZE; i++) // look for empty space (prevents collisons)
        {
            int index = (HashCode(key) + i) % ARRAY_SIZE; // first checks original hashcode then moves on 

            if (_hashtable[index] == null) // found an empty spot
            {
                HashData<T> hashItem = new HashData<T>(key, inventoryItem);
                _hashtable[index] = hashItem; // added

                _itemsInArray++; // increase counter

                return true;//stop looping when added
            }
        }
        return false;
    }

    public bool Delete(int key)
    {

        for (int i = 0; i < ARRAY_SIZE; i++) // to find an empty spot
        {
            int index = (HashCode(key) + i) % ARRAY_SIZE; // first checks original hashcode then moves on 

            if ((_hashtable[index] != null) && (_hashtable[index].key == key)) // found it 
            {
                _hashtable[index] = null; // mark as deleted 
                return true;
            }
        }
        return false;
    }

    public HashData<T> Search(int key)
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

    public HashData<T>[] Display()
    {
        return _hashtable;
    }

    public int HashCode(int key)
    {
        return key % ARRAY_SIZE;
    }

}


