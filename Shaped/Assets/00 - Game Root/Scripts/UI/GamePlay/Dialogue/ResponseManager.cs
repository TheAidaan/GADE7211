using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ResponseManager : MonoBehaviour
{
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
            _responseTexts[i].text = responses.ElementAt(i).Text;      
           
        if (!numberOfResponses.Equals(_responseTexts.Length))
            for (int i = numberOfResponses; i < _responseTexts.Length; i++)
                _responseTexts[i].text = "~";
    }

    public void ResponceOne()
    {
        DialogueManager.Static_Response(0);
    }
    public void ResponceTwo()
    {
        DialogueManager.Static_Response(1);
    }
    public void ResponceThree()
    {
        DialogueManager.Static_Response(2);
    }
}
