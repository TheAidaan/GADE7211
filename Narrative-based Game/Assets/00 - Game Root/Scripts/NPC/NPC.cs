using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character // all characters need a name and a path directing to their current dialogue json
{
    public string Name;
    public string File;

    public Character(string name, string file)
    {
        Name = name;
        File = file;
    }
}

/*-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-*/

public abstract class NPC : MonoBehaviour
{
    Character _me; // declare a new character

    public void AssignAttributes(string name, string file)
    {
        _me = new Character(name, file); //initialising a new character with the inputed values
    }

   public Character GetCharacterAttributes() // name and specified dialoguePath is made public 
   {
        return _me;
   }
}
