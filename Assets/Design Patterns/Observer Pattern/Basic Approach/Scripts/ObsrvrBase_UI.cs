using UnityEngine;
using UnityEngine.SceneManagement;

public class ObsrvrBase_UI : MonoBehaviour
{
    /// <summary>
    /// Responsible for handling UI operations
    /// </summary>

    private ObsrvrBase_Knight _ObsrvrBase_Knight;
    private ObsrvrBase_KingGoblin _ObsrvrBase_KingGoblin;

    private void Awake()
    {
        // Getting components as they are on the same game object
        _ObsrvrBase_KingGoblin = GetComponent<ObsrvrBase_KingGoblin>();
        _ObsrvrBase_Knight = GetComponent<ObsrvrBase_Knight>();
    }

    public void DieMech(bool isGoblin)
    {
        // When die button is pressed
        if (isGoblin)
            // If Goblin Die pressed, calling die on Goblin
            _ObsrvrBase_KingGoblin.GoblinDead();
        else
            // If Knight Die pressed, calling die on Knight
            _ObsrvrBase_Knight.KnightDead();
    }

    public void Restart()
    {
        // Restart Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheckUnityApproach()
    {
        // To go to the Unity's Observer Pattern implementation approach scene
        SceneManager.LoadScene((int)ScenesEnum.ObserverPatternUnityApproach);
    }
}
