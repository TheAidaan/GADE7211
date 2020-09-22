using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    GameObject[] _uiParts = new GameObject[2]; // to store the different Canvases //
   

    bool _showPauseOverlay;

    private void Start()
    {
        _showPauseOverlay = false;

        for (int i = 0; i < 2; i++)
        {
            _uiParts[i] = transform.GetChild(i).gameObject; // add children into GameObject[] array
        }
        SetUI();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_showPauseOverlay)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    void SetUI()
    {
 /*
   0:  DialogueBox
   1:  Pause Overlay
   2:  Player Inventory

 */
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
    public void Continue()
    {
        Time.timeScale = 1;
        _showPauseOverlay = false;
        SetUI();

    }

}
