using System.Collections;
using System.Collections.Generic;
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
    }

    public virtual void Exit(){}

    public virtual void LogicUpdate()
    {
        moveDir = player.inputHandler.rawMovementInput.normalized; //get a vector value between 0 and 1 that represents the direction to move
        Debug.Log(moveDir);
    }

    public virtual void PhysicsUpdate(){}
}
