using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    public Animator anim;

    BaseState _currentState;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void TransitionToState(BaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
}
