using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action PickNeons;
    static Sprite[] _iconSpriteSheet;
    public static Sprite[] GameIcons { get { return _iconSpriteSheet; } } //indexes 1-5: NPC icons. idexes 5+: item icons

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
        _iconSpriteSheet = Resources.LoadAll<Sprite>("IconSpriteSheet");
    }
    private void FixedUpdate()
    {
        
    }

    void    IvokePickNeons()
    {
        if (PickNeons != null)
            PickNeons.Invoke();
    }

    public static void Static_IvokePickNeons()
    {
        instance.IvokePickNeons();
    }

}
