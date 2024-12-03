using UnityEngine;
using UnityEngine.SceneManagement;

public class Obsrvr_UI : MonoBehaviour
{
    /// <summary>
    /// Responsible for UI operations
    /// </summary>

    private Obsrvr_Knight _Obsrvr_Knight;
    private Obsrvr_KingGoblin _Obsrvr_KingGoblin;

    private void Awake()
    {
        // Getting components as they are on the same game object
        _Obsrvr_KingGoblin = GetComponent<Obsrvr_KingGoblin>();
        _Obsrvr_Knight = GetComponent<Obsrvr_Knight>();
    }

    public void DieMech(bool isGoblin)
    {
        // When die button is pressed
        if (isGoblin)
            // If Goblin Die pressed, calling die on Goblin
            _Obsrvr_KingGoblin.GoblinDead();
        else
            // If Knight Die pressed, calling die on Knight
            _Obsrvr_Knight.KnightDead();
    }

    public void Restart()
    {
        // Restart Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheckBasicApproach()
    {
        // To go to the basic Observer Pattern implementation approach scene
        SceneManager.LoadScene((int)ScenesEnum.ObserverPatternBasicApproach);
    }
}
