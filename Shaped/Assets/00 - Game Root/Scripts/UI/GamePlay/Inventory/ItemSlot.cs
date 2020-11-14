using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    string _name;
    Image _icon;
    Sprite empty;
    void Awake()
    {

        _icon = transform.GetChild(0).GetComponent<Image>(); // GetComponentInchildren was being problematic 

        empty = _icon.sprite;


        if (_icon == null)
        {
            Debug.Log(gameObject.name + " does not have a child image");
        }
    }
    public void DestroyItem()
    {
        _name = string.Empty;
        _icon.sprite = empty;
        SlideOut();

    }
    public void SetItem(InventoryItem item) //get the item from the parent
    {
        _name = item.name; // take the name from the item
        SetImage(GameManager.Sprites[item.iconID]); // set image to be the item icon
    }

    public void SetImage(Sprite sprite)
    {
        SlideIn();
       
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
    public void MouseHoverEnter()
    {
        MouseHoverText.ShowHoverText_Static(_name);
    }
    public void MouseHoverExit()
    {
        MouseHoverText.HideHoverText_Static();
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
    public void SlideOut()
    {
        LeanTween.moveLocalX(gameObject, 500, .2f).setEaseInOutBounce();

    }
    #endregion
}
