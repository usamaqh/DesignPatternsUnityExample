using UnityEngine;
using UnityEngine.InputSystem;

public class StateMchn_KnightMovement : MonoBehaviour
{
    /// <summary>
    /// Class responsible for knight's movement
    /// Handling the states as required
    /// </summary>

    public float moveSpeed; // Knight movement speed

    // Knight's different movement states
    internal StateMchn_KnightIdleState idleState = new StateMchn_KnightIdleState();
    internal StateMchn_KnightWalkState walkState = new StateMchn_KnightWalkState();
    internal StateMchn_KnightAttackState attackState = new StateMchn_KnightAttackState();

    private StateMchn_KnightBaseState _currentState;

    // Input for Knight's movement and attack
    internal InputAction moveAction;
    internal InputAction attackAction;

    internal Animator animator;

    public AnimationClip attackClip;

    private void Start()
    {
        animator = GetComponent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        // By default initially Knight will be in the Idle State
        _currentState = idleState; // Setting the current state as Idle State
        _currentState.EnterState(this); // Entering the state for the state to take charge and perform relevent operations
    }

    private void Update()
    {
        _currentState.UpdateState(this); // Updates per frame, performed by the current state we are in
    }

    public void SwitchState(StateMchn_KnightBaseState StateMchn_KnightBaseState)
    {
        // This method switches the current state to the provided state
        _currentState = StateMchn_KnightBaseState;
        StateMchn_KnightBaseState.EnterState(this);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // For trigger detection
        _currentState.OnTriggerEnter(collision);
    }
}
