using UnityEngine;

public class StateMchn_Goblin : MonoBehaviour
{
    /// <summary>
    /// Responsible for Golbin die mechanism when hit with sword
    /// </summary>

    public GameObject skull;

    private bool _isAlive = true;

    internal void Die()
    {
        // If already dead, do nothing
        if (!_isAlive)
            return;

        // If alive, make it die!
        _isAlive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        skull.SetActive(true);
    }
}
