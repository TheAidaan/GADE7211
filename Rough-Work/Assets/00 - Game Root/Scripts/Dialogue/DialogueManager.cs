using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.PackageManager;

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

    TextMeshProUGUI _npcNametxt, _npcDialoguetxt, _playerNametxt, _playerDialoguetxt;
    GameObject _dialogueBox;

    static bool _activeDialogue;
    public static bool activeDialogue { get { return _activeDialogue; } }

    DoublyLinkedList _currentDialogue = new DoublyLinkedList();

    private void Awake()
    {
        instance = this;//..ton
    }

    void Start()
    {
        _dialogueBox = GetComponentInChildren<Image>().gameObject;

        _npcNametxt = _dialogueBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _npcDialoguetxt = _dialogueBox.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _playerNametxt = _dialogueBox.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _playerDialoguetxt = _dialogueBox.transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        _dialogueBox.SetActive(false);

        //ReadFile("Test");
    }

    private void Update()
    {
        Dialogue Current; // make an empty dialogue variable that stores the NPC - player sentence exchanges

        if ((_activeDialogue) && (Input.GetKeyDown(KeyCode.D)))        // player can't move player character anymore so D only moves the dialogue foward
        {
            Current = _currentDialogue.Next(); // store the next exchange in a varaible 

            if (Current != null) // is it at the end of the list?)
            {
                Dialogue(Current); //say this, if not at the end
            }
            else
            {
                _currentDialogue.Clear(); // is at the end, clear the list
                _dialogueBox.SetActive(false); // turn off the dialogueBox for now
                _activeDialogue = false; //no more dialogue available atm

            }

        }

        if ((_activeDialogue)&&(Input.GetKeyDown(KeyCode.A)))        // player can't move player character anymore so A only moves the dialogue backwards
        {
            Dialogue(_currentDialogue.Previous()); // say the previous sentence, if it's at the begnning, it will always and only say the head 

         
        }
    }

    void Dialogue(Dialogue current) //speak with what you currently have
    {
        _npcDialoguetxt.text = current.NPCText;
        _playerDialoguetxt.text = current.Response;

    }

    public void AddToCurrentDialogue(Dialogue node)
    {
        _currentDialogue.AddNode(node);
    }

    public void StartDialogue(string NPCName)
    {
        _activeDialogue = true;

        _dialogueBox.SetActive(true);
        _npcNametxt.text = "PC"; 
        _playerNametxt.text = "Sqaure";

        Dialogue(_currentDialogue.Next()); //starts at the beginning
    }

    public static void LoadFile(Character NPC) //anyone can call this = anyone can speak
    {
        DialogueNodes JsonNodes = new DialogueNodes();

        TextAsset asset = Resources.Load<TextAsset>("DialogueFiles/"+ NPC.File); // get the text asset with the NPC file name 
        if (asset != null) //was there a text asset?
        {
            JsonNodes = JsonUtility.FromJson<DialogueNodes>(asset.text); // put it into a generic list

            foreach (Dialogue node in JsonNodes.dialogue)
            {
                instance.AddToCurrentDialogue(node); // puts it into linked list
            }

            instance.StartDialogue(NPC.Name); // send the NPC name 
        }
        else
        {
            Debug.Log("No json file.");
        }
    }
}
