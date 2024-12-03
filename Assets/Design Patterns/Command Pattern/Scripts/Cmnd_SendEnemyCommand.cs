public class Cmnd_SendEnemyCommand : Cmnd_ICommand
{
    /// <summary>
    /// Custom sendenemy command
    /// King goblin will use this to send the required enemy towards the knight
    /// </summary>

    private Cmnd_GoblinTroop _Cmnd_GoblinTroop;

    public Cmnd_SendEnemyCommand(Cmnd_GoblinTroop Cmnd_GoblinTroop)
    {
        // caching the goblin that the king goblin has commanded to march, but waiting to be executed
        _Cmnd_GoblinTroop = Cmnd_GoblinTroop;
    }

    public override void Execute()
    {
        // it's this goblins turn to march toward knight, execting
        _Cmnd_GoblinTroop.StartMarch(this);
    }
}
