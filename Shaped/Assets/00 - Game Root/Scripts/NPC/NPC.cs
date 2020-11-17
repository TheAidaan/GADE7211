using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    bool _random; //is the NPC a spefic npc that drives the game or not
    public bool IsTalking;
    public string Name { get; }

    int _dialogueID = 1;
    public string File { 
        get 
        {
            
            string file;

            if (_random)
            {
                file = "RandomNPCs/Shape";
                _dialogueID = Random.Range(1, 11);
            }
            else
            {
                if (PlayerStats.SpokenToElli)
                    _dialogueID = 2;
                if (PlayerStats.GaveNeonToElli)
                    _dialogueID = 3;
                if (PlayerReact.ElliRanAway)
                    _dialogueID = 4;
                if (Name.Equals("Elli"))
                    _dialogueID = 1;
                file = "ImportantNPCs/" + Name;
            }
                
            if (_dialogueID < 10)
            {
                file = file + "0" + _dialogueID;
            }
            else
            {
                file = file + _dialogueID;
            }

            return file;
        } 
    }
    public int IconID { get; }
    public float TextDelay { get; }

    public Character(string name, float textDelay,int iconID, bool random)
    {
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
    public void AssignAttributes(string Name, float TextDelay, int IconID, bool random)
    {
        _character = new Character(Name, TextDelay, IconID, random); //initialising a new character with the inputed values
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
        gameObject.tag = "Destroy";
    }
}
