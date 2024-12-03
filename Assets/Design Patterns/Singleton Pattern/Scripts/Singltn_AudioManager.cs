using UnityEngine;

public class Singltn_AudioManager : MonoBehaviour
{
    /// <summary>
    /// AudioManager Singleton instance
    /// Responsible for handling audio tasks
    /// </summary>
    /// 

    // This is the instance of this class
    public static Singltn_AudioManager Instance;

    public AudioClip atkGoblinClip;
    public AudioClip atkKnightClip;

    private AudioSource _audioSrce;

    private void Awake()
    {
        // Creating the instance
        if (!Instance) // this is same as Instance == null
        {
            Instance = this; // Assinging this class instance

            _audioSrce = GetComponent<AudioSource>();
        }
    }

    internal void PlaySound(bool isGoblin)
    {
        // Playing the sound of the Attack
        // If Goblin then Goblin sound
        // If Knight then Knight sound
        _audioSrce.PlayOneShot(isGoblin ? atkGoblinClip : atkKnightClip);
    }

    public bool IsPlaying()
    { 
        return _audioSrce.isPlaying; 
    }
}
