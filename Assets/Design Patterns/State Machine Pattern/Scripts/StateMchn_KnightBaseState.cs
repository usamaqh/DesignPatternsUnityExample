using UnityEngine;

public abstract class StateMchn_KnightBaseState
{
    /// <summary>
    /// This is an abstract class responsible for having the necessary functions that all the states will have
    /// </summary>
    /// <param name="StateMchn_KnightMovement"></param>

    // For when the state is selected, this function is a must
    public abstract void EnterState(StateMchn_KnightMovement StateMchn_KnightMovement);

    // For each update action performed by the state per frame, this function is a must
    public abstract void UpdateState(StateMchn_KnightMovement StateMchn_KnightMovement);

    // Trigger detection
    public abstract void OnTriggerEnter(Collider2D collision);
}
