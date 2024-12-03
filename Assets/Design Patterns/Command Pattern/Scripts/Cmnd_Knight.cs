using UnityEngine;

public class Cmnd_Knight : MonoBehaviour
{
    /// <summary>
    /// Handles the Knight behaviour
    /// When a goblin is in range it attacks
    /// </summary>
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagsHolderEnum.Goblin.ToString()))
        {
            // If the goblin is in Knight's trigger range, then Attack and make the goblin die
            _animator.SetTrigger("Attack");
            collision.GetComponent<Cmnd_GoblinTroop>().Die();
        }
    }
}
