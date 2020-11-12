using UnityEngine;

public class PlayerAnimations : CharacterAnimator
{
    readonly CharacterWalkingState WalkingState = new CharacterWalkingState();
    readonly CharacterIdleState IdleState = new CharacterIdleState();
    readonly CharacterTalkingState TalkingState = new CharacterTalkingState();

    private void Start()
    {
        TransitionToState(IdleState);
    }

    private void Update()
    {
        if (PlayerMovement.Moving || PlayerNavAgentController.NavMeshActive)
            TransitionToState(WalkingState);
        else if (DialogueManager.activeDialogue)
            TransitionToState(TalkingState);
        else
            TransitionToState(IdleState);
    }




}
    
