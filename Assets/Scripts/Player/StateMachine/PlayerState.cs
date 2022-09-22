using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected float startTime;
    protected Vector2 moveDir;

    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        player.dashState.canDash = true;
    }

    public virtual void Exit(){}

    public virtual void LogicUpdate()
    {
        moveDir = player.inputHandler.rawMovementInput.normalized; //get a vector value between 0 and 1 that represents the direction to move

        player.inputHandler.CheckDashHoldTime();

        if(player.inputHandler.dashInput && player.dashState.CheckCanDash()  && moveDir != Vector2.zero)
        {
            stateMachine.ChangeState(player.dashState);
        }

        if(player.dashState.dashComplete)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

    public virtual void PhysicsUpdate(){}
}
