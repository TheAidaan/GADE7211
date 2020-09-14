using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public void ShowDialogueBox()
    {
        LeanTween.moveY(gameObject,200, .2f).setEaseInOutBounce();
       
    }
    public void HideDialogueBox()
    {
        LeanTween.moveY(gameObject, -200, .15f).setEaseInOutBounce();  
    }
}
