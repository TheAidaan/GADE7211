using UnityEngine;
using TMPro;

public class MouseHoverText : MonoBehaviour
{
    static MouseHoverText instance;//single...

    const float TEXT_PADDING = 4;

    TextMeshProUGUI _text;
    RectTransform _backgroundRect, _parentRect;
    private void Awake()
    {
        instance = this;//...ton
    }
    
    void Start()
    {
        _backgroundRect = GetComponent<RectTransform>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _parentRect = transform.parent.GetComponent<RectTransform>();
        //HideHoverText();
    }

    void Update()
    {
        #region Makes text follow mouse
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (_parentRect, Input.mousePosition, Camera.main, out localPoint); //take in the mouse position, in realtion to the parent canvas and feed it to a variable 
        transform.localPosition = localPoint; // move the positon to the variable 
        #endregion

        #region Makes text stay on screen
        Vector2 newAnchoredPosition = _backgroundRect.anchoredPosition;
        if ((newAnchoredPosition.x + _backgroundRect.rect.width) > _parentRect.rect.width) // check if the text is breaching the screen limits
        {
            newAnchoredPosition.x = _parentRect.rect.width - _backgroundRect.rect.width; // creat new anchored position
            _backgroundRect.anchoredPosition = newAnchoredPosition;//set neww anchored position
        }
        #endregion


    }

    void ShowHoverText(string text)
    {
        gameObject.SetActive(true); //activate
        transform.SetAsLastSibling();

        _text.text = text; //set text
        Vector2 backgroundSize = new Vector2(_text.preferredWidth + TEXT_PADDING * 2, _text.preferredHeight + TEXT_PADDING * 2); //make a size for the backround with enough space to make text look comfortable
        _backgroundRect.sizeDelta = backgroundSize; //set size

    }
    void HideHoverText()
    {
        gameObject.SetActive(false); //deactivate
    }

    public static void ShowHoverText_Static(string text) // for anybody
    {
       instance.ShowHoverText(text);
    }
    public static void HideHoverText_Static()//for anybody
    {
        instance.HideHoverText();
    }
}
