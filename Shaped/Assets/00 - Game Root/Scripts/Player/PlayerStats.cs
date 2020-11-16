using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    int _health;
    bool _hurt;
    static bool _gaveNeonToElli;
    public static bool GaveNeonToElli{ get { return _gaveNeonToElli; } }

    public static

    Queue<string> _completeObjectives = new Queue<string>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _gaveNeonToElli = false;
        _health = 25;
    }

    void Update()
    {
        if (GameManager.CanMove && _completeObjectives.Count !=0) // the conditions for moving are the same conditions whereby very little is happening in the game(no text input, no dialogue, no navmesh acitive)
            StartCoroutine(Reward());
    }

    void TakeDamage()
    {
        _health--;
        if (_health < 20)
            _hurt = true;

    }
    bool ObjectiveCheck(int ID)
    {
        switch (ID)
        {
            case 1: return _hurt;
            default:
                return false;
        }
    }

    void ObjectiveCompleter(int ID)
    {
        switch (ID)
        {
            case 1:  
                _health +=2;
               _completeObjectives.Enqueue("You made a friend");
                break;
            case 2:
                _gaveNeonToElli = true;
                _health += 3;
                break;
            default:
                 Debug.Log("Invalid Objective ID");
                break;
        }
    }

    IEnumerator Reward()
    {
        AlertBox.Static_ObjectiveCompleteAlert(_completeObjectives.Dequeue());
        yield return new WaitForSeconds(2.5f);
        AlertBox.Static_Hide();
    }
    /*              PUBLIC STATICS              */

    public static void Static_TakeDamage()
    {
        instance.TakeDamage();
    }
    public static bool Static_ObjectiveCheck(int ID)
    {
        return instance.ObjectiveCheck(ID);
    }

    public static void Static_ObjectiveCompleter(int ID)
    {
        instance.ObjectiveCompleter(ID);
    }
}
