using UnityEngine;

public class ObsrvrBase_Knight : ObsrvrBase_Subject, ObsrvrBase_IObserver
{
    /// <summary>
    /// Responsible for handling Knight death operations and notifying observers of knight's death
    /// </summary>
  
    public GameObject skull;

    [SerializeField] private Animator knightAnim;
    [SerializeField] private Animator[] knightTroopAnimArr;

    internal bool _isAlive = true;

    private ObsrvrBase_KingGoblin _ObsrvrBase_KingGoblin;

    #region UnityFunctions
    private void Awake()
    {
        _ObsrvrBase_KingGoblin = GetComponent<ObsrvrBase_KingGoblin>();
    }

    private void OnEnable()
    {
        // Knight adding itself as an observer to Golbin die Event, to let Knight know of when the goblin dies
        _ObsrvrBase_KingGoblin.AddObserver(this);
    }

    private void OnDisable()
    {
        // removing itself as observer to Golbin die event
        _ObsrvrBase_KingGoblin.RemoveObserver(this);
    }
    #endregion UnityFunctions

    #region WhenGoblinDied
    public void OnNotify()
    {
        // goblin dies, goblin notified the knight that he died and knight has won and knight troops should be happy
        KnightWon();
    }

    private void KnightWon()
    {
        knightAnim.SetTrigger("Won");

        SetTroopAnim("Happy");
    }
    #endregion WhenGoblinDied

    #region WhenPlayerDied
    internal void KnightDead()
    {
        // When knight dies, notifying the subscribers that the knight died
        NotifyObservers();

        // Knight died, hence troops are sad
        KnightLost();
    }

    private void KnightLost()
    {
        if (!_ObsrvrBase_KingGoblin.isAlive)
            return;

        _isAlive = false;

        knightAnim.gameObject.SetActive(false);
        skull.SetActive(true);

        SetTroopAnim("Sad");
    }
    #endregion WhenPlayerDied

    private void SetTroopAnim(string triggerName)
    {
        int len = knightTroopAnimArr.Length;
        for (int i = 0; i < len; i++)
        {
            knightTroopAnimArr[i].SetTrigger(triggerName);
        }
    }
}
