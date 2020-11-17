using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{

    public Animator anim;

    public  BaseState currentState;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TransitionToState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
