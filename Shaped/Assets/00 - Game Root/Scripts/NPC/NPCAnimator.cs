using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCAnimator : MonoBehaviour
{
    public Animator anim;

    NPCBaseState _currentState;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void TransitionToState(NPCBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
}
