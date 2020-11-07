using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public void ShowDialogueBox(int numberOFChoices)
    {
        Debug.Log(numberOFChoices);
        float height = 5 + 65 * numberOFChoices;
        LeanTween.moveY(gameObject, height, .2f).setEaseInOutBounce();
       
    }
    public void HideDialogueBox()
    {
        LeanTween.moveY(gameObject, -360, .15f).setEaseInOutBounce();  
    }
}
