using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cmnd_SendEnemyInvoker : MonoBehaviour
{
    /// <summary>
    /// Invoker of commands
    /// Stores the commands into a data structure and executes the action as required
    /// </summary>

    // commands queue, to store command and execute as First in First Out (FIFO)
    private Queue<Cmnd_ICommand> commandsQueue = new Queue<Cmnd_ICommand>();
    private Cmnd_ICommand _currentCommand;

    // Array of goblin troops which can be commanded to march
    [SerializeField] private Cmnd_GoblinTroop[] Cmnd_GoblinTroopsArr;

    public void AddCommand(int member)
    {
        // Add send enemy command to the queue, with the king goblin's desired enemy to send
        Cmnd_SendEnemyCommand command = new Cmnd_SendEnemyCommand(Cmnd_GoblinTroopsArr[member - 1]);
        commandsQueue.Enqueue(command);
    }

    private void Update()
    {
        // Checking every frame if there are commands in the queue and next commmand can be processed
        ProcessCommand();
    }

    private void ProcessCommand()
    {
        // if invoker has a current command in hand
        // and is not finished then wait for it to complete before going to the next one
        if (_currentCommand != null && !_currentCommand.isFinished)
            return;

        // if there are no other commands remaining in the queue, do nothing
        if (!commandsQueue.Any())
            return;

        // execute the next in queue command
        _currentCommand = commandsQueue.Dequeue();
        _currentCommand.Execute();
    }
}
