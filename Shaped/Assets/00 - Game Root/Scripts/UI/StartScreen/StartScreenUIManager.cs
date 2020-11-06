using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenUIManager : MonoBehaviour
{
    const int NUMBER_OF_CHILDREN = 4;
    GameObject[] _children = new GameObject[4]; //[0] panel, [1] title, [2] playButton, [3] quitButton

    private void Awake()
    {
        for (int i = 0; i < NUMBER_OF_CHILDREN; i++)
        {
            _children[i] = transform.GetChild(i).gameObject;
        }

    }
    private void Start()
    {
        StartCoroutine(MovePanel());
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void MoveButtons()
    {
        LeanTween.alpha(_children[2].GetComponentInChildren<RectTransform>(), 0f, 1f).setEase(LeanTweenType.linear);
        LeanTween.moveX(_children[2], 250, .5f); //move play button
        LeanTween.moveX(_children[3], 250, .5f); // move quit button
    }

    IEnumerator MovePanel()
    {

        yield return new WaitForSeconds(0.5f);

        LeanTween.scaleY(_children[0], 1, 0.5f);

        yield return new WaitForSeconds(1f);

        LeanTween.moveX(_children[1], 75, .5f); //move title
        MoveButtons();
    }
}
