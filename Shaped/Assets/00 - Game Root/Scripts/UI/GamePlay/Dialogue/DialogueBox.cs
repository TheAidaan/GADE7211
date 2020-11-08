using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public void ShowDialogueBox()
    {
        LeanTween.moveLocalY(gameObject, 150, .15f).setEaseInOutBounce();      
    }
    public void HideDialogueBox()
    {
        LeanTween.moveLocalY(gameObject, 300, .2f).setEaseInOutBounce();
         
    }
}
