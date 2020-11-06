using UnityEngine;
using TMPro;

public class MouseHoverText : MonoBehaviour
{
    static MouseHoverText instance;//single...

    const float TEXT_PADDING = 4;

    TextMeshProUGUI _text;
    RectTransform _backgroundRect, _parentRect;

    Canvas _parentCanvas;
    private void Awake()
    {
        instance = this;//...ton
    }
    
    void Start()
    {
        _backgroundRect = GetComponent<RectTransform>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _parentRect = transform.parent.GetComponent<RectTransform>();
        _parentCanvas = GetComponentInParent<Canvas>();

        HideHoverText();
    }

    void Update()
    {
        #region Makes text follow mouse and stay on screen
        Vector3 newPos = Input.mousePosition; //take in the mouse position, in realtion to the parent canvas and feed it to a variable 

        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + _backgroundRect.rect.width * _parentCanvas.scaleFactor / 2) - 25;
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }

        transform.position = newPos; // move the positon to the variable 
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
