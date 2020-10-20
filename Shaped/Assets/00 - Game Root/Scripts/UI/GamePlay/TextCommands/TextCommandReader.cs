using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

#region TextCommand struct
public struct TextCommand // structor for all Inventory items
{
    public TextCommand(string Command /*string File*/)
    {
        command = Command;
        //Action = Action;
    }

    public int Key()// matches the key function in the textCommandReader class exacly (MUST)
    {
        int length = command.Length;
        int key = 0;

        for (int i = 0; i < length; i++)
        {
            key += (int)command[i];
        }

        return key;
    }
    public string command { get; } // the text required for the command to activate

    /* public string Action { get; }*/ // the path for the display icon
}
#endregion

public class TextCommandReader : MonoBehaviour
{
    #region Text Command Library & Add all Commands function

    TextCommand Hello = new TextCommand("hello");

    void AddAllCommands() 
    {
        bool added;
        added = _textCommands.Add(Hello.Key(), Hello); // the add, might be successful, might not 

        if (!added)
        {
            Debug.Log("Command: " + Hello + "not added");
        }
    }

    #endregion
    
    TMP_InputField _input;
    HashTable<TextCommand> _textCommands = new HashTable<TextCommand>(); //the player inventory

    private void Awake()
    {
        AddAllCommands(); // add all commands to the hashtable
    }
    void Start()
    {
        _input = GetComponentInChildren<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) 
        {
            ReadInput();
        }
        
    }
    void ReadInput()
    {
        string inputText = _input.text.ToLower(); // get the input from the player and lower all the letters
        GetKey(inputText); 
    }

    void GetKey(string text) // matches the key function in the text command struct exacly (MUST)
    {
        int length = text.Length;
        int key = 0;

        for (int i = 0; i < length; i++)
        {
            key += (int)text[i];
        }

        if (_textCommands.Search(key) != null)
        {
            Debug.Log("Found");
        }
        else
        {
            Debug.Log("Text Command unrecognised");
        }
    }

    

}
