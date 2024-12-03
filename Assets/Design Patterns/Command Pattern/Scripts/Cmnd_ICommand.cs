public abstract class Cmnd_ICommand
{
    // interface for command that will be implemented in custom command classes
    public abstract void Execute(); // must have this method

    public bool isFinished = false; // to check if the current command has finished executing
}
