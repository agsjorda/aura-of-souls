using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float moveSpeed;
    
    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D rb2D { get; private set; }

    #endregion
    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb2D.velocity = new Vector2(xVelocity, yVelocity);
    }
}
