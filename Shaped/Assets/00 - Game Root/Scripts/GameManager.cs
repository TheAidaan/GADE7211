using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameManager instance;

    static Sprite[] _spriteSheet;
    public static Sprite[] sprites { get { return _spriteSheet; } } //indexes 1-5: NPC icons. idexes 5+: item icons
    

    static bool _playerCanMove;
    public static bool CanMove { get { return _playerCanMove; } }

    private void Awake()
    {
        instance = this;
        _spriteSheet = Resources.LoadAll<Sprite>("IconSpriteSheet");
    }

    public static void EnablePlayerMovement()
    {
        _playerCanMove = true;
    }

    public static void DisablePlayerMovement()
    {
        _playerCanMove = false;
    }
}
