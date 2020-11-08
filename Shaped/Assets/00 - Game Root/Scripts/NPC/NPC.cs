using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    public bool IsTalking;
    public int NumberOfDialogueFiles { get; }
    public string Name { get; }

    int DialogueID = 1;
    public string File { 
        get 
        {
            if (DialogueID > NumberOfDialogueFiles)
            {
                DialogueID--;
            }

            if (DialogueID<10)
            {
                return Name + "0" + DialogueID;
            }
            else
            {
                return Name + DialogueID;
            }
        } 
    }
    public int IconID { get; }
    public float TextDelay { get; }

    public Character(string name, int numberOfDialogueFiles, float textDelay,int iconID)
    {
        NumberOfDialogueFiles = numberOfDialogueFiles;
        Name = name;
        TextDelay = TextDelay;
        IconID =iconID;

    }
}

/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/

public abstract class NPC : MonoBehaviour
{
   // public Vector3 movementDir;

    Character _character; // declare a new character

    public void AssignAttributes(string Name, int NumberOfDialogueFiles, float TextDelay, int IconID)
    {
        _character = new Character(Name, NumberOfDialogueFiles, TextDelay, IconID); //initialising a new character with the inputed values
        GetComponentInParent<NPCcontroller>().AssignCharacter(_character);
    }

    public Character GetCharacterAttributes() // name and specified dialoguePath is made public 
    {
        return _character;
    }
}
