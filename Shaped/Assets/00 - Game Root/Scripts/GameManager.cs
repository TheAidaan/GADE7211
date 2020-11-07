using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    static Sprite[] _spriteSheet;
    public static Sprite[] sprites { get { return _spriteSheet; } } //indexes 1-5: NPC icons. idexes 5+: item icons
    
    static bool _playerCanMove = true;
    public static bool CanMove { get { return _playerCanMove; } }

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

    public static void EnablePlayerMovement()
    {
        _playerCanMove = true;

        if ( (DialogueManager.activeDialogue)||(GameUI.GamePaused)||(GameUI.ExpectingText))
        {
            _playerCanMove = false;
        }
    }

    public static void DisablePlayerMovement()
    {
        _playerCanMove = false;
    }

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
