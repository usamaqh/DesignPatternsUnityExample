using UnityEngine;

public class Cmnd_GoblinTroop : MonoBehaviour
{
    /// <summary>
    /// Responsible for Goblin to be commanded march and die mechanism
    /// </summary>

    [SerializeField] private Transform knightTransfrm;

    private Animator _animator;

    private bool _toMarch = false;

    public GameObject skull;

    private Cmnd_ICommand _Cmnd_ICommand;

    [SerializeField] private Cmnd_KingGoblin Cmnd_KingGoblin;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        March();
    }

    #region MarchMech
    private void March()
    {
        if (_toMarch)
        {
            // march towards the knight
            transform.position = Vector2.MoveTowards(transform.position, knightTransfrm.position, Time.deltaTime);

            if (Vector2.Distance(transform.position, knightTransfrm.position) <= 0.1f)
                _toMarch = false;
        }
    }

    internal void StartMarch(Cmnd_ICommand Cmnd_ICommand)
    {
        // Gotten the command from king goblin to march towards the knight!
        _Cmnd_ICommand = Cmnd_ICommand;
        _toMarch = true;
        _animator.SetTrigger("Walk");
    }
    #endregion MarchMech

    #region DieMech
    internal void Die()
    {
        Invoke(nameof(DieAfterDelay), 0.2f);
    }

    private void DieAfterDelay()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        skull.SetActive(true);

        // finishing the current command execution
        _Cmnd_ICommand.isFinished = true;

        // letting the king goblin to add a new command if any
        Cmnd_KingGoblin.CommandEnemy();

        Invoke(nameof(HideTroop), 1f);
    }

    private void HideTroop()
    {
        gameObject.SetActive(false);
    }
    #endregion DieMech
}
