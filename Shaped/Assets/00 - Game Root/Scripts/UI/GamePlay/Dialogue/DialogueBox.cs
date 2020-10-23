using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public void ShowDialogueBox()
    {
        LeanTween.moveY(gameObject, 15f, .2f).setEaseInOutBounce();
       
    }
    public void HideDialogueBox()
    {
        LeanTween.moveY(gameObject, -360, .15f).setEaseInOutBounce();  
    }
}
