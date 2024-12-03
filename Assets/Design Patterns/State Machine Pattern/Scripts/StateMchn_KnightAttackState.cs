using UnityEngine;

public class StateMchn_KnightAttackState : StateMchn_KnightBaseState
{
    /// <summary>
    /// Attack state for when the Knight is attacking
    /// Knight can go to Idle or Walk state from Attack state
    /// </summary>

    private float _timer = 0f;

    private StateMchn_Goblin _StateMchn_Goblin;

    public override void EnterState(StateMchn_KnightMovement StateMchn_KnightMovement)
    {
        // Entering the Attack state thus start attack animation
        StateMchn_KnightMovement.animator.SetTrigger("Attack");
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        // Detecting if the goblin in in trigger range of the sword
        if (collision.CompareTag("Goblin"))
            // caching the attacked goblin for later use
            _StateMchn_Goblin = collision.GetComponent<StateMchn_Goblin>();
    }

    public override void UpdateState(StateMchn_KnightMovement StateMchn_KnightMovement)
    {
        // Checking when the sword animation will end
        if (_timer > StateMchn_KnightMovement.attackClip.length)
        {
            // if goblin attacked, making the cached goblin die
            _StateMchn_Goblin?.Die();

            _timer = 0f;

            // Checking the movement values for the change in states
            if (StateMchn_KnightMovement.moveAction.ReadValue<Vector2>().magnitude > 0)
                // If moving then switch from Attack to Walk State
                StateMchn_KnightMovement.SwitchState(StateMchn_KnightMovement.walkState);
            else
                // If knight is at rest, switch from Attack to Idle State
                StateMchn_KnightMovement.SwitchState(StateMchn_KnightMovement.idleState);
        }
        else
            // Increasing sword animation end wait timer by delta time per frame
            _timer += Time.deltaTime;
    }
}
