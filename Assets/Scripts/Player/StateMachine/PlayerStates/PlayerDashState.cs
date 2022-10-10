using UnityEngine;

public class PlayerDashState : PlayerState
{
    public bool canDash;    
    public bool dashComplete;
    private Vector2 dashDir;
    private float lastDash;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine){}

    public override void Enter()
    {
        base.Enter();

        canDash = false;
        dashComplete = false;
        player.inputHandler.dashInput = false;
        dashDir = player.inputHandler.RawMovementInput.normalized;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Debug.Log("Dash State");

        player.SetDashVelocity(PlayerData.dashSpeed, dashDir);

        if(Time.time >= startTime + PlayerData.dashTime)
        {
            dashComplete = true;
            lastDash = Time.time;
        }    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool CheckCanDash()
    {
        return canDash && (Time.time >= lastDash + PlayerData.dashCooldown);
    }
}
