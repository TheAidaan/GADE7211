using System.Collections;//4,567752
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenUIManager : MonoBehaviour
{
    const int NUMBER_OF_UI_CONSTANTS = 1;// the number of children that must be ignored so that they always stay on the screen
    const int NUMBER_OF_CHILDREN = 2;
    GameObject[] _UIParts = new GameObject[4]; //[0] Main, [1] Settings, [2] playButton, [3] quitButton

    bool _showMainMenu, _showSettingsMenu;

    private void Start()
    {
        int index = 0;
        for (int i = NUMBER_OF_UI_CONSTANTS; i < NUMBER_OF_UI_CONSTANTS+NUMBER_OF_CHILDREN; i++) 
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
    public void SetSoundVolume(float volume)
    {
        SoundManager.Static_SetSoundVolume(volume);
    }
    public void SetMusicVolume(float volume)
    {
        SoundManager.Static_SetMusicVolume(volume);
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
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
