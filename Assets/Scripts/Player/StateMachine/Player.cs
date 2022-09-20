using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine stateMachine {get; private set;}
    public PlayerIdleState idleState {get; private set;}
    public PlayerMoveState moveState {get; private set;}
    #endregion

    #region Component Variables
    public PlayerInputHandler inputHandler {get; private set;}
    public Rigidbody2D rb {get; private set;}
    #endregion

    #region Movement Variables
    public Vector2 currentVelocity {get; private set;}
    #endregion

    #region Unity Callback Functions
    void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine);
        moveState = new PlayerMoveState(this, stateMachine);
    }

    void Start()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initilaize(idleState); //start the game in the default state
    }

    void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
        currentVelocity = rb.velocity;
    }
    #endregion

    public void SetMovementVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
        currentVelocity = velocity;
    }
}
