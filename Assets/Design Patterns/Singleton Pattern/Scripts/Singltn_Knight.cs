using UnityEngine;

public class Singltn_Knight : MonoBehaviour
{
    [SerializeField] private Animator animator;

    internal void Attack()
    {
        if (Singltn_AudioManager.Instance.IsPlaying())
            return;

        // Playing the knight attack sound and animation
        // Singltn_AudioManager.Instance to call the play sound directly without the need to refernce it 
        Singltn_AudioManager.Instance.PlaySound(false);
        animator.SetTrigger("Attack");
    }
}
