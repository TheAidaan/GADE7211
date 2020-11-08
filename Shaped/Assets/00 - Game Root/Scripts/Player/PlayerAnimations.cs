using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    readonly PlayerTalkingState TalkingState = new PlayerTalkingState();

    public Animator anim;

    PlayerBaseSate _currentState;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    
    public void TransitionToState(PlayerBaseSate state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
}
