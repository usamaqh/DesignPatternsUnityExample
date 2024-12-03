using UnityEngine;

public class Singltn_UI : MonoBehaviour
{
    /// <summary>
    /// This class handles the UI operations for the Singleton pattern example
    /// </summary>

    // Reference to the classes
    private Singltn_Knight _Singltn_Knight;
    private Singltn_KingGoblin _Singltn_KingGoblin;

    private void Start()
    {
        // Getting the class components as they all are on the same game object
        _Singltn_Knight = GetComponent<Singltn_Knight>();
        _Singltn_KingGoblin = GetComponent<Singltn_KingGoblin>();
    }

    public void Attack(bool isGoblin)
    {
        // Attack button is pressed 
        if (isGoblin)
            // If Goblin Attack button pressed calling the attack function in Singltn_KingGoblin class
            _Singltn_KingGoblin.Attack();
        else
            // If Knight Attack button pressed calling the attack function in Singltn_Knight class
            _Singltn_Knight.Attack();
    }
}
