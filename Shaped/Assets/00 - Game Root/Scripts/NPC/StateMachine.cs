using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(CharacterAnimator character);
    public abstract void Update(CharacterAnimator character);
    public abstract void OnCollisonEnter(CharacterAnimator character);
}

public class CharacterIdleState : BaseState
{
    public override void EnterState(CharacterAnimator character)
    {
        character.anim.SetBool("Walk", false);
        character.anim.SetBool("Talking", false);
    }

    public override void OnCollisonEnter(CharacterAnimator character)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(CharacterAnimator character)
    {
        throw new System.NotImplementedException();
    }
}

public class CharacterWalkingState : BaseState
{
    public override void EnterState(CharacterAnimator character)
    {
        character.anim.SetBool("Walk", true);
    }

    public override void OnCollisonEnter(CharacterAnimator character)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(CharacterAnimator character)
    {
        throw new System.NotImplementedException();
    }
}

public class CharacterTalkingState : BaseState
{
    public override void EnterState(CharacterAnimator character)
    {
        character.anim.SetBool("Talking", true);
    }

    public override void OnCollisonEnter(CharacterAnimator character)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(CharacterAnimator character)
    {
        throw new System.NotImplementedException();
    }
}