using UnityEngine;

public class StateMchn_KnightWalkState : StateMchn_KnightBaseState
{
    /// <summary>
    /// Walk state for when the Knight is moving
    /// Knight can go to Attack or Idle state from Walk state
    /// </summary>
    /// <param name="StateMchn_KnightMovement"></param>

    public override void EnterState(StateMchn_KnightMovement StateMchn_KnightMovement)
    {
        // Entering the Walk state thus start walking animation
        StateMchn_KnightMovement.animator.SetBool("Walk", true);
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
            // If attack button pressed, switching state from Walk to Attack state
            StateMchn_KnightMovement.SwitchState(StateMchn_KnightMovement.attackState);
        else if (moveValue.magnitude <= 0)
            // If the knight is at rest, switching state from Walk to Idle state
            StateMchn_KnightMovement.SwitchState(StateMchn_KnightMovement.idleState);
        else
            // Moving the knight in the direction of movement
            StateMchn_KnightMovement.transform.Translate(Time.deltaTime * moveValue * StateMchn_KnightMovement.moveSpeed);
    }
}
