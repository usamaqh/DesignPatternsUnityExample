using UnityEngine;

public class Obsrvr_Knight : MonoBehaviour
{
    /// <summary>
    /// Responsible for handling Knight death operations
    /// Having event for PlayerDeath
    /// </summary>

    private Obsrvr_KingGoblin _Obsrvr_KingGoblin;

    public GameObject skull;

    [SerializeField] private Animator knightAnim;
    [SerializeField] private Animator[] knightTroopAnimArr;

    internal bool isAlive = true;

    public delegate void KnightDeath(); // Delegate for Knight's death using which the event will be created
    public event KnightDeath OnKnightDeath; // Knight's death event

    #region UnityFunctions
    private void Awake()
    {
        _Obsrvr_KingGoblin = GetComponent<Obsrvr_KingGoblin>();
    }

    private void OnEnable()
    {
        // Knight subscribing to Golbin die Event, to let Knight know of when the goblin dies
        _Obsrvr_KingGoblin.OnGoblinDeath += OnGoblinDeath;
    }

    private void OnDisable()
    {
        // unsubscribing to Golbin die event
        _Obsrvr_KingGoblin.OnGoblinDeath -= OnGoblinDeath;
    }
    #endregion UnityFunctions

    #region WhenGoblinDied
    private void OnGoblinDeath()
    {
        // goblin dies, knight won and troops should be happy
        KnightWon();
    }

    private void KnightWon()
    {
        knightAnim.SetTrigger("Won");

        SetTroopAnim("Happy");
    }
    #endregion WhenGoblinDied

    #region WhenKnightDied
    internal void KnightDead()
    {
        /* When knight dies, checking if the playerdeath event is subscribed by any class, then invoking it to let subscribers 
           know of that the knight died*/
        OnKnightDeath?.Invoke();

        // Knight died, hence troops are sad
        KnightLost();
    }

    private void KnightLost()
    {
        if (!_Obsrvr_KingGoblin.isAlive)
            return;

        isAlive = false;

        knightAnim.gameObject.SetActive(false);
        skull.SetActive(true);

        SetTroopAnim("Sad");
    }
    #endregion WhenKnightDied

    private void SetTroopAnim(string triggerName)
    {
        int len = knightTroopAnimArr.Length;
        for (int i = 0; i < len; i++)
        {
            knightTroopAnimArr[i].SetTrigger(triggerName);
        }
    }
}
