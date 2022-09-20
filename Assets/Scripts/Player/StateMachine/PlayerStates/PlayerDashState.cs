using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    private bool canDash;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine){}

    public override void Enter()
    {
        base.Enter();

        canDash = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetDashVelocity(PlayerData.dashSpeed, moveDir);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
