using UnityEngine;

public class StateMchn_KnightIdleState : StateMchn_KnightBaseState
{
    /// <summary>
    /// Idle state for when the Knight is not moving and not attacking
    /// Knight can go to Attack or Walk state from idle state
    /// </summary>
    /// <param name="StateMchn_KnightMovement"></param>

    public override void EnterState(StateMchn_KnightMovement StateMchn_KnightMovement)
    {
        // Entering the Idle state thus if walking then stop walking
        StateMchn_KnightMovement.animator.SetBool("Walk", false);
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        // No need for trigger operations here
    }

    public override void UpdateState(StateMchn_KnightMovement StateMchn_KnightMovement)
    {
        // Checking the movement/attack values for the change in states
        Vector2 moveValue = StateMchn_KnightMovement.moveAction.ReadValue<Vector2>();
        bool attackValue = StateMchn_KnightMovement.attackAction.IsPressed();

        if (attackValue)
            // If attack button pressed, switching state from Idle to Attack state
            StateMchn_KnightMovement.SwitchState(StateMchn_KnightMovement.attackState);
        else if (moveValue.magnitude > 0)
            // If there is movement, switching state from Idle to walk state
            StateMchn_KnightMovement.SwitchState(StateMchn_KnightMovement.walkState);
    }
}
