using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Move Info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Atttack Info")]
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;

    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();


        if (isPlayerDetected())
        {
            Debug.Log(isPlayerDetected().collider.gameObject.name + "There you are");
        }

    }
    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();


    public virtual RaycastHit2D isPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 30, whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));
    }
}
