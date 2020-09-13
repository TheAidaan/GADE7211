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
    Character _me; // declare a new character

    public void AssignAttributes(string name, string file, float textDelay)
    {
        _me = new Character(name, file, textDelay); //initialising a new character with the inputed values
    }

   public Character GetCharacterAttributes() // name and specified dialoguePath is made public 
   {
        return _me;
   }
}
