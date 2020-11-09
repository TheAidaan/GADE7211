using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    const int NUMBER_OF_UI_PARTS = 4;
    GameObject[] _uiParts = new GameObject[NUMBER_OF_UI_PARTS]; // to store the different Canvases //

    public static bool ExpectingText {get { return _showInputTextOverlay; }}
    public static bool GamePaused { get { return _showPauseOverlay; } }

    static bool _showPauseOverlay,_showInputTextOverlay;

    private void Start()
    {
        int x=0;
        for (int i = 1; i < NUMBER_OF_UI_PARTS+1; i++)
        {
            _uiParts[x] = transform.GetChild(i).gameObject; // add children into GameObject[] array
            x++;
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_showInputTextOverlay)
            {
                HideInputTextOverlay();
            }
            else
            {
                ShowInputTextOverlay();
            }
        }
    }

    void SetUI()
    {
        /*
          0:  DialogueBox
          1:  Pause Overlay
          2:  Player Inventory
          3:  Input Text Overlay

        */
        _uiParts[1].SetActive(_showPauseOverlay);
        _uiParts[3].SetActive(_showInputTextOverlay);

        if (_showInputTextOverlay)
        {
            _uiParts[3].GetComponent<TextCommandReader>().ActivateInputField();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        _showPauseOverlay = true;
        SetUI();
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
        Continue();

    }
    public void Continue()
    {
        Time.timeScale = 1;
        _showPauseOverlay = false;
        SetUI();

    }

    public void HideInputTextOverlay()
    {
        _showInputTextOverlay = false;
        SetUI();

    }

    public void ShowInputTextOverlay()
    {
        _showInputTextOverlay = true;
        SetUI(); 
        
    }

}
