using UnityEngine;
using UnityEngine.SceneManagement;

public class Cmnd_UI : MonoBehaviour
{
    /// <summary>
    /// Responsible for handling UI operations
    /// </summary>

    private bool _isStarted = false;

    private Cmnd_KingGoblin _Cmnd_KingGoblin;

    private void Start()
    {
        _Cmnd_KingGoblin = GetComponent<Cmnd_KingGoblin>();
    }

    public void StartCommand()
    {
        if (_isStarted)
            return;

        _isStarted = true;

        // enabling the king goblin to give commands to his troops
        _Cmnd_KingGoblin.CommandEnemy();
    }

    public void Restart()
    {
        // reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
