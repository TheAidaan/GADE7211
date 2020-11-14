using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    int health;
    bool _hurt;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        health = 25;
    }
    // Start is called before the first frame update
    void TakeDamage()
    {
        health--;
        if (health < 20)
            _hurt = true;

    }
    bool ObjectiveControl(int ID)
    {
        switch (ID)
        {
            case 1: return _hurt;
            default:
                return false;
        }
    }
    /*              PUBLIC STATICS              */

    public static void Static_TakeDamage()
    {
        instance.TakeDamage();
    }
    public static bool Static_ObjectiveCheck(int ID)
    {
        return instance.ObjectiveControl(ID);
    }
}
