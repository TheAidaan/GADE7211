using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    public string name { get; }
    public string file { get; }

    public float textDelay { get; }

    public Character(string Name, string File, float TextDelay)
    {
        name = Name;
        file = File;
        textDelay = TextDelay;

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
    public void AssignAttributes(string Name, string File, float TextDelay)
    {
        _me = new Character(Name, File, TextDelay); //initialising a new character with the inputed values
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
