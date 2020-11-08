using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueAlert : MonoBehaviour
{
    TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void Show(string message)
    {
        _text.text = message;
        LeanTween.moveY(gameObject, 15, .1f).setEaseInOutBounce();

    }

    public void Hide()
    {
        LeanTween.moveY(gameObject, -240, .1f).setEaseInOutBounce();
    }
}
