using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    string _name;
    Image _icon;
    void Start()
    {
        _icon = transform.GetChild(0).GetComponent<Image>(); // GetComponentInchildren was being problematic 
        
        if (_icon == null)
        {
            Debug.Log(gameObject.name + " does not have a child image");
        }
    }

    public void SetItem(InventoryItem item) //get the item from the parent
    {
        _name = item.name; // take the name from the item
        SetImage(item.file); // set image to be the item icon
    }

    public void SetImage(string file)
    {
        SlideIn();

       Sprite sprite = Resources.Load<Sprite>("InventoryIcons/" + file); // get the sprite with the file name 
       
        if (sprite != null)
        {
            if (_icon != null)
            {
                _icon.sprite = sprite; // great, found it, add it after checking if icon is still there
            }else
            {
                Debug.Log(gameObject.name + " does not have a child image");
            }
            
        }
        else
        {
            Debug.Log("No sprite found"); // this is why it's not working
        }
    }
    #region Mouse Reactions
    public void MouseHover()
    {
        Debug.Log(_name);
    }

    public void MouseClick()
    {
        Debug.Log(_name);
    }
    #endregion

    #region Display Animations
    void SlideIn()
    {
        LeanTween.moveLocalX(gameObject, 350, .2f).setEaseInOutBounce();
       
    }
    #endregion
}
