using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(CharacterAnimator character);
}

public class CharacterIdleState : BaseState
{
    public override void EnterState(CharacterAnimator character)
    {
        character.anim.SetBool("Walk", false);
        character.anim.SetBool("Talking", false);
    }
}

public class CharacterWalkingState : BaseState
{
    public override void EnterState(CharacterAnimator character)
    {
        character.anim.SetBool("Walk", true);
    }
}

public class CharacterTalkingState : BaseState
{
    public override void EnterState(CharacterAnimator character)
    {
        character.anim.SetBool("Talking", true);
    }
}