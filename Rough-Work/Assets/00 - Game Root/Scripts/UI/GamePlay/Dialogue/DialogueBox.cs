using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public void ShowDialogueBox()
    {
        LeanTween.moveY(gameObject, 75, .2f).setEaseInOutBounce();
       
    }
    public void HideDialogueBox()
    {
        LeanTween.moveY(gameObject, -75, .15f).setEaseInOutBounce();  
    }
}
