using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource backgroundMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Para que el AudioManager persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopAllSound()
    {
        backgroundMusic.Stop();
    }
}
