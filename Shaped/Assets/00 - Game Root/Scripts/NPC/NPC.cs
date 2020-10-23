using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    public string name { get; }
    public string file;
    public int iconID { get; }
    public float textDelay { get; }

    public Character(string Name, float TextDelay,int IconID)
    {
        name = Name;
        textDelay = TextDelay;
        iconID = IconID;

    }
}

/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/

public abstract class NPC : MonoBehaviour
{
    public int numberOfDialogueFiles;
    int _dialogueID = 0;
    public Vector3 movementDir;

    Animator _anim;
    Character _me; // declare a new character

    void Awake()
    {
        if (GetComponentInChildren<Animator>() != null) // if there's not animator on the npc
        {
            _anim = GetComponentInChildren<Animator>();
        }
        else
        {
            Debug.Log(gameObject.name + " does not have an Animator");// this why it ain't working
        }

    }
    public void AssignAttributes(string Name, float TextDelay, int IconID)
    {
        _me = new Character(Name, TextDelay, IconID); //initialising a new character with the inputed values
        NextDialogueFile();
    }

    public Character GetCharacterAttributes() // name and specified dialoguePath is made public 
    {
        return _me;
    }

    public void AnimateWalking(bool isWalking)
    {
        _anim.SetBool("isWalking", isWalking);
    }

    public void NextDialogueFile() // called to change the dialogue file
    {
        if(_dialogueID< numberOfDialogueFiles) //is there room to go forward?
        {
            _dialogueID++;
        }
        
        if (_dialogueID < 10)
        {
            _me.file = _me.name +"0" +_dialogueID; //i just like it like this
        }
        else
        {
            _me.file = _me.name + _dialogueID;
        }
    }
}
