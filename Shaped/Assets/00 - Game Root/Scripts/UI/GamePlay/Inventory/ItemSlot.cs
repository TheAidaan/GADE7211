using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    string _name;
    Image _icon;
    void Start()
    {
        _icon = transform.GetChild(0).GetComponent<Image>(); // GetComponentInchildren was being problematic 
    }

    public void SetItem(InventoryItem item) //get the item from the parent
    {
        _name = item.name; // take the name from the item
        SetImage(item.file); // set image to be the item icon
    }

    public void SetImage(string file)
    {
        Sprite sprite = Resources.Load<Sprite>("InventoryIcons/" + file); // get the sprite with the file name 

        if (sprite != null)
        {
            _icon.sprite = sprite; // great, found it, done.
        }
        else
        {
            Debug.Log("No sprite found"); // this is why it's not working
        }
    }

    private void OnMouseOver()
    {
        Debug.Log(_name);
    }

    private void OnMouseEnter()
    {
        Debug.Log(_name);
    }
}
