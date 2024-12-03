using UnityEngine;

public class ObsrvrBase_KingGoblin : ObsrvrBase_Subject, ObsrvrBase_IObserver
{
    /// <summary>
    /// Responsible for handling Knight death operations and notifying observers of goblin's death
    /// </summary>
    /// 
    public GameObject skull;

    [SerializeField] private Animator goblinAnim;
    [SerializeField] private Animator[] goblinTroopAnimArr;

    internal bool isAlive = true;

    private ObsrvrBase_Knight _ObsrvrBase_Knight;

    #region UnityFunctions
    private void Awake()
    {
        _ObsrvrBase_Knight = GetComponent<ObsrvrBase_Knight>();
    }

    private void OnEnable()
    {
        // Goblin adding itself as an observer to Knight die Event, to let Knight know of when the knight dies
        _ObsrvrBase_Knight.AddObserver(this);
    }

    private void OnDisable()
    {
        // removing itself as observer to Knight die event
        _ObsrvrBase_Knight.RemoveObserver(this);
    }
    #endregion UnityFunctions

    #region WhenKnightDied
    public void OnNotify()
    {
        // knight dies, knight notified the goblin that he died and goblin has won and goblin troops should be happy
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
        // When goblin dies, notifying the subscribers that the goblin died
        NotifyObservers();

        // goblin died, hence troops are sad
        GoblinLost();
    }

    private void GoblinLost()
    {
        if (!_ObsrvrBase_Knight._isAlive)
            return;

        isAlive = false;

        goblinAnim.gameObject.SetActive(false);
        skull.SetActive(true);

        SetTroopAnim("Sad");
    }
    #endregion WhenEnemyDied

    private void SetTroopAnim(string triggerName)
    {
        int len = goblinTroopAnimArr.Length;
        for (int i = 0; i < len; i++)
        {
            goblinTroopAnimArr[i].SetTrigger(triggerName);
        }
    }
}
