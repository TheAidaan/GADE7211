using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    public string Name;
    public string File;

    public float TextDelay;

    public Character(string name, string file, float textDelay)
    {
        Name = name;
        File = file;
        TextDelay = textDelay;
    }
}

/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/

public abstract class NPC : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 movementDir;

    Animator _anim;
    Character _me; // declare a new character

    void Awake()
    {
        if (GetComponent<Rigidbody2D>() != null) // if there's no rigidbody on the npc
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.Log(gameObject.name + " does not have a Rigidbody2D"); // this why it ain't working
        }

        if (GetComponentInChildren<Animator>() != null) // if there's not animator on the npc
        {
            _anim = GetComponentInChildren<Animator>();
        }
        else
        {
            Debug.Log(gameObject.name + " does not have an Animator");// this why it ain't working
        }

    }
    public void AssignAttributes(string name, string file, float textDelay)
    {
        _me = new Character(name, file, textDelay); //initialising a new character with the inputed values
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
