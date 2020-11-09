using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogueChoiceManager : MonoBehaviour
{

    const int TEXT_PADDING_WIDTH = 80;
    const int TEXT_PADDING_HEIGHT = 65;
    const int NUMBER_OF_BUTTONS = 3;
    TextMeshProUGUI[] _responseTexts = new TextMeshProUGUI[3];
    RectTransform[] _buttonRecTransforms = new RectTransform[3];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            _responseTexts[i] = transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();
            _buttonRecTransforms[i] = transform.GetChild(i).GetComponentInChildren<RectTransform>();
        }
           
    }

    public void ActivateButtons(List<Response> responses)
    {
        int numberOfResponses = responses.Count;
        for (int i = 0; i < numberOfResponses; i++)
        {           
            _responseTexts[i].text = responses.ElementAt(i).Text;
            Vector2 backgroundSize = new Vector2(_responseTexts[i].preferredWidth + TEXT_PADDING_WIDTH, TEXT_PADDING_HEIGHT); //make a size for the backround with enough space to make text look comfortable

            _buttonRecTransforms[i].GetComponentInParent<RectTransform>().sizeDelta = backgroundSize;
            LeanTween.moveLocalX(_responseTexts[i].transform.parent.gameObject, backgroundSize.x/-2, 0.2f);
        }
                      
    }

    public void HideAllButtons()
    {
        for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
        {
            Vector2 backgroundSize = new Vector2(TEXT_PADDING_WIDTH, TEXT_PADDING_HEIGHT); //make a size for the backround with enough space to make text look comfortable
            _buttonRecTransforms[i].GetComponentInParent<RectTransform>().sizeDelta = backgroundSize;
            LeanTween.moveLocalX(_responseTexts[i].transform.parent.gameObject, 160, 0.2f);
        }
           
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
