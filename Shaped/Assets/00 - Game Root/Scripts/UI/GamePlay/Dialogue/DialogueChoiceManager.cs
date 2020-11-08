using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogueChoiceManager : MonoBehaviour
{
    const int NUMBER_OF_BUTTONS = 3;
    TextMeshProUGUI[] _responseTexts = new TextMeshProUGUI[3];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
            _responseTexts[i] = transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ActivateButtons(List<Response> responses)
    {
        int numberOfResponses = responses.Count;
        for (int i = 0; i < numberOfResponses; i++)
        {
            LeanTween.moveLocalX(_responseTexts[i].transform.parent.gameObject, -80, 0.2f);
            _responseTexts[i].text = responses.ElementAt(i).Text;
        }
                      
    }

    public void HideAllButtons()
    {
        for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            LeanTween.moveLocalX(_responseTexts[i].transform.parent.gameObject, 160, 0.2f);
    }

    public void ResponceOne()
    {
        HideAllButtons();
        DialogueManager.Static_Response(0);
    }
    public void ResponceTwo()
    {
        HideAllButtons();
        DialogueManager.Static_Response(1);
    }
    public void ResponceThree()
    {
        HideAllButtons();
        DialogueManager.Static_Response(2);
    }
}
