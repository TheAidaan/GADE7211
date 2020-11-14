using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    static Sprite[] _spriteSheet;
    public static Sprite[] Sprites { get { return _spriteSheet; } } //indexes 1-5: NPC icons. idexes 5+: item icons
    
    public static bool CanMove 
    { 
        get 
        {
            if (DialogueManager.activeDialogue || GameUI.GamePaused || GameUI.ExpectingText || PlayerNavAgentController.NavMeshActive)
                return false;
            return true;    
        } 
    }



    private void Awake()
    {
        instance = this;
        _spriteSheet = Resources.LoadAll<Sprite>("IconSpriteSheet");
    }


    void IncreaseInternalDamage()
    {

    }

    /*              PUBLIC STATICS              */

    public static void MissionControl(int missionID)
    {
        switch (missionID)
        {
            case 0: // make a friend(made friends with Trap
                
                break;
            default:
                Debug.Log("invalid Mission ID");
                break;
           
        }
    }

  
}
