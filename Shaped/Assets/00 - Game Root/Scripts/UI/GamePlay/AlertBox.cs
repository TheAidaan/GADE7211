using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AlertBox : MonoBehaviour
{
    readonly AlertBox_InActiveState _inactiveState = new AlertBox_InActiveState();

    static AlertBox_BaseState _currentState;
    public static AlertBox_BaseState CurrentState { get{ return _currentState; } }
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
        _currentState = _inactiveState;
        instance = this;
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _uiSpriteSheet = Resources.LoadAll<Sprite>("UIBoxesSpriteSheet");
    }

    public void Show(string message)
    {
        _text.text = message;
        LeanTween.moveY(gameObject, 15, .1f).setEaseOutBounce();
    }

    public void Hide()
    {
        LeanTween.moveY(gameObject, -240, .15f).setEaseInBounce();
    }
    public void ChangeImage(int index)
    {
        _image.sprite = _uiSpriteSheet[index];
    }

    void TransitionToState(AlertBox_BaseState state, string message)
    {
        _currentState = state;
        _currentState.EnterState(instance, message);
    }

    /*              PUBLIC STATICS             */

    public static void Deactivate()
    {
        instance.TransitionToState(instance._inactiveState, "");
    }

    public static void Static_TransitionToState(AlertBox_BaseState state, string message)
    {
        instance.TransitionToState(state, message);
    }

}
