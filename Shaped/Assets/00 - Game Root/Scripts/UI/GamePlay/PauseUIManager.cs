using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    const int NUMBER_OF_UI_CONSTANTS = 2;// the number of children that must be ignored so that they l;ways stay on the screen
    const int NUMBER_OF_CANVASES = 2;
    GameObject[] _UIParts = new GameObject[2]; //[0] Main, [1] Settings, [2] playButton, [3] quitButton

    bool _showMainMenu, _showSettingsMenu;
    void Start()
    {
        int index = 0;
        for (int i = NUMBER_OF_UI_CONSTANTS; i < NUMBER_OF_UI_CONSTANTS + NUMBER_OF_CANVASES; i++)
        {
            _UIParts[index] = transform.GetChild(i).gameObject;
            index++;
        }
        _showMainMenu = true;
        SetUI();
    }

    void SetUI()
    {
        /*
         0:  Main
         1:  Settings
       */
        _UIParts[0].SetActive(_showMainMenu);
        _UIParts[1].SetActive(_showSettingsMenu);
    }

    public void Back()
    {
        _showMainMenu = true;
        _showSettingsMenu = false;
        SetUI();
    }

    public void Settings()
    {
        _showMainMenu = false;
        _showSettingsMenu = true;
        SetUI();
    }
}
