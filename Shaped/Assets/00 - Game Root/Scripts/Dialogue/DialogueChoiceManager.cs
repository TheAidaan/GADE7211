using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DialogueChoiceManager : MonoBehaviour
{

    const int TEXT_PADDING_WIDTH = 80;
    const int TEXT_PADDING_HEIGHT = 65;
    const int NUMBER_OF_BUTTONS = 3;

    Image[] _images = new Image[3];
    TextMeshProUGUI[] _responseTexts = new TextMeshProUGUI[3];
    RectTransform[] _buttonRecTransforms = new RectTransform[3];

    Sprite empty;

    List<Response> _currentResponses;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            _buttonRecTransforms[i] = transform.GetChild(i).GetComponent<RectTransform>();
            _responseTexts[i] = _buttonRecTransforms[i].GetComponentInChildren<TextMeshProUGUI>();
            _images[i] = _buttonRecTransforms[i].transform.GetChild(1).GetComponentInChildren<Image>();
        }

        empty = _images[1].sprite;
           
    }

    public void ActivateButtons(List<Response> responses)
    {
        _currentResponses = responses;
        int numberOfResponses = _currentResponses.Count;

        for (int i = 0; i < numberOfResponses; i++)
        {           
            if (_currentResponses.ElementAt(i).ItemRequired != 0) // 0 is the default value, if it's 0 there's no item required for this dialogue path
            {
                HashData<InventoryItem> item = PlayerInventory.inventory.Search(_currentResponses.ElementAt(i).ItemRequired);

                if (item != null)// found it
                {
                    _images[i].sprite = GameManager.Sprites[item.data.iconID]; // show player what item let them say this 

                    ShowButton(_buttonRecTransforms[i], _responseTexts[i], _currentResponses.ElementAt(i).Text); // say this
                    _buttonRecTransforms[i].GetComponent<Button>().onClick.AddListener(() => PlayerInventory.Delete(item.data)); //clicking button will remove the item
                }
            }
            else if (_currentResponses.ElementAt(i).ObjectiveRequired != 0) // 0 is the default value, if it's 0 there's no objective required for this dialogue path
            {
                bool pass = PlayerStats.Static_ObjectiveCheck(_currentResponses.ElementAt(i).ObjectiveRequired);

                if (pass)
                    ShowButton(_buttonRecTransforms[i], _responseTexts[i], _currentResponses.ElementAt(i).Text);
                else
                    continue;
                   
                
            }else
                ShowButton(_buttonRecTransforms[i], _responseTexts[i], _currentResponses.ElementAt(i).Text);
                         
            
        }
                      
    }
    void ShowButton(RectTransform button, TextMeshProUGUI text, string message)
    {
        text.text = message;
        Vector2 backgroundSize = new Vector2(text.preferredWidth + TEXT_PADDING_WIDTH, TEXT_PADDING_HEIGHT); //make a size for the backround with enough space to make text look comfortable

        button.sizeDelta = backgroundSize;
        LeanTween.moveLocalX(button.gameObject, backgroundSize.x / -2, 0.2f);
    }

    public void HideAllButtons()
    {
        for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
        {
            LeanTween.moveLocalX(_responseTexts[i].transform.parent.gameObject, 160, 0.2f);
            _responseTexts[i].text = "";
            Vector2 backgroundSize = new Vector2(TEXT_PADDING_WIDTH, TEXT_PADDING_HEIGHT); //make a size for the backround with enough space to make text look comfortable
            _buttonRecTransforms[i].GetComponentInParent<RectTransform>().sizeDelta = backgroundSize;

            _images[i] .sprite = empty;
            
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
