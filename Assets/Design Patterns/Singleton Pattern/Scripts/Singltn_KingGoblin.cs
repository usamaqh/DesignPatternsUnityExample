using UnityEngine;

public class Singltn_KingGoblin : MonoBehaviour
{
    [SerializeField] private Animator animator;

    internal void Attack()
    {
        if (Singltn_AudioManager.Instance.IsPlaying())
            return;

        // Playing the goblin attack sound and animation
        // Singltn_AudioManager.Instance to call the play sound directly without the need to refernce it 
        Singltn_AudioManager.Instance.PlaySound(true);
        animator.SetTrigger("Attack");
    }
}
