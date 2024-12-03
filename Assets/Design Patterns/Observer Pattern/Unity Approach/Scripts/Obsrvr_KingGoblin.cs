using UnityEngine;

public class Obsrvr_KingGoblin : MonoBehaviour
{
    /// <summary>
    /// Responsible for handling Goblin death operations
    /// Having event for EnemyDeath
    /// </summary>
    /// 
    private Obsrvr_Knight _Obsrvr_Knight;

    public GameObject skull;

    [SerializeField] private Animator goblinAnim;
    [SerializeField] private Animator[] goblinTroopAnimArr;

    internal bool isAlive = true;

    public delegate void GoblinDeath(); // Delegate for Goblin's death using which the event will be created
    public event GoblinDeath OnGoblinDeath; // Goblin's death event

    #region UnityFunctions
    private void Awake()
    {
        _Obsrvr_Knight = GetComponent<Obsrvr_Knight>();
    }

    private void OnEnable()
    {
        // Goblin subscribing to Knight die Event, to let Goblin know of when the knight dies
        _Obsrvr_Knight.OnKnightDeath += OnKnightDeath;
    }

    private void OnDisable()
    {
        // unsubscribing to Knight die event
        _Obsrvr_Knight.OnKnightDeath -= OnKnightDeath;
    }
    #endregion UnityFunctions

    #region WhenKnightDied
    private void OnKnightDeath()
    {
        // Knight dies, goblin won and troops should be happy
        GoblinWon();
    }

    private void GoblinWon()
    {
        goblinAnim.SetTrigger("Won");

        SetTroopAnim("Happy");
    }
    #endregion WhenKnightDied

    #region WhenGoblinDied
    internal void GoblinDead()
    {
        /* When goblin dies, checking if the enemydeath event is subscribed by any class, then invoking it to let subscribers 
           know of that the goblin died*/
        OnGoblinDeath?.Invoke();

        GoblinLost();
    }

    private void GoblinLost()
    {
        if (!_Obsrvr_Knight.isAlive)
            return;

        isAlive = false;

        goblinAnim.gameObject.SetActive(false);
        skull.SetActive(true);

        SetTroopAnim("Sad");
    }
    #endregion WhenGoblinDied

    private void SetTroopAnim(string triggerName)
    {
        int len = goblinTroopAnimArr.Length;
        for (int i = 0; i < len; i++)
        {
            goblinTroopAnimArr[i].SetTrigger(triggerName);
        }
    }
}
