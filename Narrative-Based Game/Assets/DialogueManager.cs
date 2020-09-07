using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Dialogue //json 
{
    public string NPCText;
    public string Response;
}
[Serializable]
public class DialogueNodes//json
{
    public List<Dialogue> dialogue = new List<Dialogue>();
}

/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/

public class DialogueManager : MonoBehaviour        // the monobehaviour 
{
    static DialogueManager instance; //single...
    Text test;

    DoublyLinkedList _currentDialogue = new DoublyLinkedList();

    private void Awake()
    {
        instance = this;//..ton
    }

    void Start()
    {
        test = GetComponent<Text>();
        ReadFile("Test");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))        // make a button (next)
        {
            test.text = _currentDialogue.Next().NPCText;
        }

        if (Input.GetKeyDown(KeyCode.A))        // make a button (previous)
        {
           
            test.text = _currentDialogue.Previous().NPCText; 

        }
    }

    public void AddToCurrentDialogue(Dialogue node)
    {
        _currentDialogue.AddNode(node);
    }

    public static void ReadFile(string path) //anyone can call this = anyone can speak
    {
        DialogueNodes JsonNodes = new DialogueNodes();

        TextAsset asset = Resources.Load<TextAsset>(path); // get the text asset with the path
        if (asset != null) //was there a text asset?
        {
            JsonNodes = JsonUtility.FromJson<DialogueNodes>(asset.text); // put it into a generic list

            foreach (Dialogue node in JsonNodes.dialogue)
            {
                instance.AddToCurrentDialogue(node); // puts it into linked list
            }
        }
        else
        {
            Debug.Log("No json file.");
        }
    }
}
