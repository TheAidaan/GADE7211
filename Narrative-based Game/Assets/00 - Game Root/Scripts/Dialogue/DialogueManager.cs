using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    DoublyLinkedList _currentDialogue = new DoublyLinkedList();
    
    
    TextMeshProUGUI _npcNametxt, _npcDialoguetxt, _playerNametxt, _playerDialoguetxt;
    Image _npcDisplayImg, _playerDisplayImg;

    TextMeshProUGUI _dialogueOptiontxt;

    static bool _activeDialogue;
    public static bool activeDialogue { get { return _activeDialogue; } }

    bool _typing, _stoptyping;
    float _textDelay = 0.12f;

    Character _currentNPC;

    DialogueBox _dialogueBox;

    private void Awake()
    {
        instance = this;//..ton
    }

    void Start()
    {
        GameObject dialogueBox = GetComponentInChildren<Image>().gameObject;

        _npcNametxt = dialogueBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _npcDisplayImg = _npcNametxt.GetComponentInChildren<Image>();
        _npcDialoguetxt = dialogueBox.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        _playerNametxt = dialogueBox.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _playerDisplayImg = _playerNametxt.GetComponentInChildren<Image>();
        _playerDialoguetxt = dialogueBox.transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        _dialogueOptiontxt = GetComponentInChildren<TextMeshProUGUI>();
        _dialogueBox = GetComponentInChildren<DialogueBox>();

        
        
        ClearDialogue();    
    }

    private void Update()
    {
        Dialogue current; // an empty dialogue variable that stores the NPC - player sentence exchanges


        if (_activeDialogue)         
        {
            _dialogueOptiontxt.gameObject.SetActive(false); //player should see that they are able to choose to talk to the npc they are currently talking to

            if (Input.GetKeyDown(KeyCode.D)) // player can't move player character anymore so D only moves the dialogue foward
            {
                if (_typing)
                {
                    _stoptyping = true;
                }
                else
                {
                    current = _currentDialogue.Next(); // store the next exchange in a varaible 

                    if (current != null) // is it at the end of the list?)
                    {
                        StartCoroutine(RunDialogue(current) ); //say this, if not at the end
                    }
                    else
                    {
                        ClearDialogue();
                    }
                }       
            }

            if (Input.GetKeyDown(KeyCode.A))    // player can't move player character anymore so A only moves the dialogue backwards
            {
                if (_typing)
                {
                    _stoptyping = true;
                }
                else
                {
                    // _current = _currentDialogue.Previous();
                    StartCoroutine(RunDialogue( _currentDialogue.Previous() ) ); // say the previous sentence, if it's at the begnning, it will always and only say the head 
                }
            }                
        }

       
    }
    IEnumerator RunDialogue(Dialogue current) /*               MAKE SIMPLIER               */
    {
        _typing = true; // lets everybody know its typing

        for (int i = 0; i < current.NPCText.Length + 1; i++) // loops throygh each character of the string
        {
            _npcDialoguetxt.text = current.NPCText.Substring(0, i); // adds a character to the end of the display text
            yield return new WaitForSeconds(_currentNPC.TextDelay); // waits a while

            if (_stoptyping) // can be broken, if player is getting annoyed
            {
                _stoptyping = false; // stopped typing
                _typing = false; // stopped typing
                _npcDialoguetxt.text = current.NPCText; // show the full text that was stopped

                break;
            }
        }

        _typing = true; // if the typing was broken earlier then it will restart

        for (int i = 0; i < current.Response.Length + 1; i++) // adds a character to the end of the display text
        {
            _playerDialoguetxt.text = current.Response.Substring(0, i); // waits a while
            yield return new WaitForSeconds(_textDelay); // can be broken, if player is getting annoyed

            if (_stoptyping) // can be broken, if player is getting annoyed
            {
                _stoptyping = false; // stopped typing
                _typing = false; // stopped typing
                _playerDialoguetxt.text = current.Response; // show the full text that was stopped

                break;
            }
        }

        _typing = false; // not typing
    }

    void ClearDialogue()
    {
        _npcNametxt.text = _npcDialoguetxt.text = _playerNametxt.text =_playerDialoguetxt.text = string.Empty; // clear all text UIs
        
        _currentNPC = null; //clear the current NPC, because you're not speaking with anybody anymore
        _currentDialogue.Clear(); // is at the end, clear the list
        _dialogueBox.HideDialogueBox(); // turn off the dialogueBox for now
        _activeDialogue = false; //no more dialogue available atm

    }

    /*              PUBLIC STATICS RECEIVERS             */

    public void AddToCurrentDialogue(Dialogue node)
    {
        _currentDialogue.AddNode(node);
    }

    public void ActivateDialogue(Character NPC)
    {
        _currentNPC = NPC;

        _dialogueBox.ShowDialogueBox();
        _npcNametxt.text = _currentNPC.Name; 

        Sprite npcIcon = Resources.Load<Sprite>("DialogueIcons/" + NPC.Name); // get specific asset

        if (npcIcon != null) // is there even an asset
        {
            _npcDisplayImg.sprite = npcIcon; // if yes the show it
        }
        else
        {
            Debug.Log("No NPC icon"); // this is why it's not working
        }

        Sprite playerIcon = Resources.Load<Sprite>("DialogueIcons/Player");

        if (npcIcon != null)
        {
            _playerDisplayImg.sprite = playerIcon;
        }
        else
        {
            Debug.Log("No Player icon");
        }
        _playerNametxt.text = "Circle";

        _activeDialogue = true;

        StartCoroutine(RunDialogue(_currentDialogue.Next() ) );//sets current dialogue text to the first node

    }

    public void ChangeDialogueOptionText(string message)
    {
        if (message == string.Empty)
        {
            _dialogueOptiontxt.gameObject.SetActive(false); // turn off the text if the string is empty 
        }
        else // activate the text and display the message
        {
            _dialogueOptiontxt.gameObject.SetActive(true);
            _dialogueOptiontxt.text = message;

        }
    }

    /*              PUBLIC STATICS              */

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

            instance.ActivateDialogue(NPC); // send the NPC name 
        }
        else
        {
            Debug.Log("No json file.");
        }
    }

    public static void GiveDialogueOption(string name) // get the NPC name that the player might talk to 
    {
        if (name != string.Empty)
        {
            instance.ChangeDialogueOptionText("Press [SPACE] to talk to " + name); // format the message if the string has a name
        }else
        {
            instance.ChangeDialogueOptionText(string.Empty); // dont format the name and send an empty string if there's no npc name given
        }
    }
       
}
