using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    public int numberOfDialogueFiles { get; }
    public string name { get; }

    public int dialogueID = 1;
    public string file { 
        get 
        {
            if (dialogueID > numberOfDialogueFiles)
            {
                dialogueID--;
            }

            if (dialogueID<10)
            {
                return name + "0" + dialogueID;
            }
            else
            {
                return name + dialogueID;
            }
        } 
    }
    public int iconID { get; }
    public float textDelay { get; }

    public Character(string Name, int NumberOfDialogueFiles, float TextDelay,int IconID)
    {
        numberOfDialogueFiles = NumberOfDialogueFiles;
        name = Name;
        textDelay = TextDelay;
        iconID = IconID;

    }
}

/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/

public abstract class NPC : MonoBehaviour
{
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
    public void AssignAttributes(string Name, int NumberOfDialogueFiles, float TextDelay, int IconID)
    {
        _me = new Character(Name, NumberOfDialogueFiles, TextDelay, IconID); //initialising a new character with the inputed values
    }

    public Character GetCharacterAttributes() // name and specified dialoguePath is made public 
    {
        return _me;
    }

    public void AnimateWalking(bool isWalking)
    {
        _anim.SetBool("isWalking", isWalking);
    }
}
