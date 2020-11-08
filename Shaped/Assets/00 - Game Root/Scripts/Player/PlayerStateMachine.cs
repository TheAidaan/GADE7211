public abstract class PlayerBaseSate
{
    public abstract void EnterState(PlayerAnimations player);
    public abstract void Update(PlayerAnimations player);
    public abstract void OnCollisonEnter(PlayerAnimations player);
}
public class PlayerIdleState : PlayerBaseSate
{
    public override void EnterState(PlayerAnimations player)
    {
        player.anim.SetBool("Walk", false);
        player.anim.SetBool("Talking", false);
    }

    public override void OnCollisonEnter(PlayerAnimations player)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(PlayerAnimations player)
    {
        throw new System.NotImplementedException();
    }
}

public class PlayerWalkingState : PlayerBaseSate
{
    public override void EnterState(PlayerAnimations player)
    {
        player.anim.SetBool("Walk", true);
    }

    public override void OnCollisonEnter(PlayerAnimations player)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(PlayerAnimations player)
    {
        throw new System.NotImplementedException();
    }
}

public class PlayerTalkingState : PlayerBaseSate
{
    public override void EnterState(PlayerAnimations player)
    {
        player.anim.SetBool("Talking", true);
    }

    public override void OnCollisonEnter(PlayerAnimations player)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(PlayerAnimations player)
    {
        throw new System.NotImplementedException();
    }
}
