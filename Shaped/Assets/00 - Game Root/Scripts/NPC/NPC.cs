using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    bool _random; //is the NPC a spefic npc that drives the game or not
    public bool IsTalking;
    public int NumberOfDialogueFiles { get; }
    public string Name { get; }

    int DialogueID = 1;
    public string File { 
        get 
        {
            string file;
            if (DialogueID > NumberOfDialogueFiles)
            {
                DialogueID--;
            }
            if (_random)
                file = "RandomNPCs/Shape";
            else
                file = "ImportantNPCs/" + Name;
            if (DialogueID<10)
            {
                
                file = file + "0" + DialogueID;
            }
            else
            {
                file = file + DialogueID;
            }

            return file;
        } 
    }
    public int IconID { get; }
    public float TextDelay { get; }

    public Character(string name, int numberOfDialogueFiles, float textDelay,int iconID, bool random)
    {
        NumberOfDialogueFiles = numberOfDialogueFiles;
        Name = name;
        TextDelay = TextDelay;
        IconID =iconID;

        _random = random;

    }
}

/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/

public abstract class NPC : MonoBehaviour
{
    // public Vector3 movementDir;

    NPCController _controller;
    Character _character; // declare a new character

    public void Awake()
    {
        _controller = GetComponentInParent<NPCController>();
    }
    public void AssignAttributes(string Name, int NumberOfDialogueFiles, float TextDelay, int IconID, bool random)
    {
        _character = new Character(Name, NumberOfDialogueFiles, TextDelay, IconID, random); //initialising a new character with the inputed values
        _controller.AssignCharacter(_character);
    }
    public void AssignSpeed(float speed)
    {
        _controller.AssignSpeed(speed);
    }

    public Character GetCharacterAttributes() // name and specified dialoguePath is made public 
    {
        return _character;
    }

    void OnTriggerExit(Collider other)
    {
        GetComponent<Collider>().isTrigger = false;
    }
}
