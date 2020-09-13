using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    static PlayerUIManager instance; // singleton (not sure if necessary)
    TextMeshProUGUI _infoText;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _infoText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplayInformation(string info)
    {
        _infoText.text = info;
    }

    public static void TakeInformation(string info)// any script can display nessecary information 
    {
        instance.DisplayInformation(info);
    }
}
