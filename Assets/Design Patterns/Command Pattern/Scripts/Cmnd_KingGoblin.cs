using TMPro;
using UnityEngine;

public class Cmnd_KingGoblin : MonoBehaviour
{
    /// <summary>
    /// King Goblin, responsible for command the enemy goblins towards the knight
    /// </summary>
    /// 
    public GameObject cmndSpriteGObj;

    [SerializeField] private Animator animator;

    private int _sendEnemyCount = 0;

    private Cmnd_SendEnemyInvoker _Cmnd_SendEnemyInvoker; // The invoker of the commands, where commands would be sent for execution

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _Cmnd_SendEnemyInvoker = GetComponent<Cmnd_SendEnemyInvoker>();
    }

    internal void CommandEnemy()
    {
        // Checking which enemy to send, current in order 1-4, you can make it random too!
        if (_sendEnemyCount >= 4)
        {
            CmndSpriteActivation(false, "");
            return;
        }

        _sendEnemyCount++;

        AnimateTrigger("Go");

        // king goblin shows which enemy he has commanded
        string msg = "GO " + _sendEnemyCount + "!";
        CmndSpriteActivation(true, msg);

        // adding the command to the invorker for execution mechanism
        _Cmnd_SendEnemyInvoker.AddCommand(_sendEnemyCount);
    }

    private void AnimateTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    private void CmndSpriteActivation(bool toShow, string text)
    {
        cmndSpriteGObj.SetActive(toShow);
        cmndSpriteGObj.transform.GetComponentInChildren<TextMeshPro>().text = text;
    }
}
