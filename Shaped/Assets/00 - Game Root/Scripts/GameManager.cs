using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    static Sprite[] _spriteSheet;
    public static Sprite[] sprites { get { return _spriteSheet; } } //indexes 1-5: NPC icons. idexes 5+: item icons
    
    public static bool CanMove 
    { 
        get 
        {
            if (DialogueManager.activeDialogue || GameUI.GamePaused || GameUI.ExpectingText)
                return false;
            return true;    
        } 
    }

    [SerializeField] GameObject _box;

    private void Awake()
    {
        instance = this;
        _spriteSheet = Resources.LoadAll<Sprite>("IconSpriteSheet");
    }

    void OutOfBox()
    {
        Destroy(_box);
    }

    /*              PUBLIC STATICS              */

    public static void MissionCompleted(int missionID)
    {
        switch (missionID)
        {
            default:
            case 1: instance.OutOfBox();
                break;
        }

    }
}
