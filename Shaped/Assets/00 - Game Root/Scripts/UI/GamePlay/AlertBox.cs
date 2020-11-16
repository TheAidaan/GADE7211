using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AlertBox : MonoBehaviour
{
    public static AlertBox instance;
    Image _image;
    TextMeshProUGUI _text;
    Sprite[] _uiSpriteSheet;

    /*
          0:  PlayerDialogueBox
          1:  AlertBox
          2:  NPCDialogueBox
          3:  RewardBox
          4:  NotificationBox

        */

    private void Awake()
    {
        instance = this;
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _uiSpriteSheet = Resources.LoadAll<Sprite>("UIBoxesSpriteSheet");
    }

    void Show(string message)
    {
        _text.text = message;
        LeanTween.moveY(gameObject, 15, .1f).setEaseOutBounce();
    }

    void Hide()
    {
        LeanTween.moveY(gameObject, -240, .15f).setEaseInBounce();
    }
    void ChangeImage(int index)
    {
        _image.sprite = _uiSpriteSheet[index];
    }

    /*              PUBLIC STATICS             */

    public static void Static_DialogueAlert(string message)
    {
        instance.ChangeImage(1);
        instance.Show(message);
    }
    public static void Static_NotificationAlert(string message)
    {
            instance.ChangeImage(4);
            instance.Show(message);
    }
    public static void Static_ObjectiveCompleteAlert(string message)
    {
        instance.ChangeImage(3);
        instance.Show(message);
    }

    public static void Static_Hide()
    {
        instance.Hide();
    }

}
