using UnityEngine;

public abstract class NPCBaseState
{
    public abstract void EnterState(NPCAnimator character);
    public abstract void Update(NPCAnimator character);
    public abstract void OnCollisonEnter(NPCAnimator character);
}

public class CharacterIdleState : NPCBaseState
{
    public override void EnterState(NPCAnimator character)
    {
        character.anim.SetBool("Walk", false);
        character.anim.SetBool("Talking", false);
    }

    public override void OnCollisonEnter(NPCAnimator character)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(NPCAnimator character)
    {
        throw new System.NotImplementedException();
    }
}

public class CharacterWalkingState : NPCBaseState
{
    public override void EnterState(NPCAnimator character)
    {
        character.anim.SetBool("Walk", true);
    }

    public override void OnCollisonEnter(NPCAnimator character)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(NPCAnimator character)
    {
        throw new System.NotImplementedException();
    }
}

public class CharacterTalkingState : NPCBaseState
{
    public override void EnterState(NPCAnimator character)
    {
        character.anim.SetBool("Talking", true);
    }

    public override void OnCollisonEnter(NPCAnimator character)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(NPCAnimator character)
    {
        throw new System.NotImplementedException();
    }
}