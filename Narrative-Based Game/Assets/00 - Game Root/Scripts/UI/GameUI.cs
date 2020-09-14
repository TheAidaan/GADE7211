using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    GameObject[] _uiParts = new GameObject[2]; // to store the different Canvases

    bool _showPauseOverlay;

    private void Start()
    {
        _showPauseOverlay = false;

        int x = 0;// for the  that stores the UIparts
        for (int i = 1; i < 3; i++) // starts at 1 to ignore the button 
        {
            _uiParts[x] = transform.GetChild(i).gameObject; // add children into GameObject[] array
            x++;
        }
        SetUI();

    }

    void SetUI()
    {
        _uiParts[1].SetActive(_showPauseOverlay);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        _showPauseOverlay = true;
        SetUI();
    }
    public void Quit()
    {
        Application.Quit();

    }
    public void Play()
    {
        Time.timeScale = 1;
        _showPauseOverlay = false;
        SetUI();

    }

}
