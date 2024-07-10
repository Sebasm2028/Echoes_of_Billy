using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Options")]
    public Slider masterVolumen;
    public Slider fxVolume;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject playPanel;

    [Header("References")]
    public PlayerController playerController; // Nueva referencia al PlayerController
    //public CameraFollow cameraFollow; // Nueva referencia al CameraFollow

    private void Awake()
    {
        // Cuando cambia el valor del slider llama la función change 
        masterVolumen.onValueChanged.AddListener(ChangeMasterVolume);
        fxVolume.onValueChanged.AddListener(ChangeFxVolume);
    }

    private void Start()
    {
        // Pausar el juego al inicio
        Time.timeScale = 0f;
        OpenPanel(mainPanel);
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        playPanel.SetActive(false);

        panel.SetActive(true);
        ButtonSound();
    }

    // Setea los valores que el usuario desea
    public void ChangeMasterVolume(float v)
    {
        mixer.SetFloat("MasterVolume", v);
    }

    public void ChangeFxVolume(float v)
    {
        mixer.SetFloat("FxVolume", v);
    }

    public void SetMute()
    {
        if (mute.isOn)
        {// Si está muteado 
            mixer.GetFloat("MasterVolume", out lastVolume);
            mixer.SetFloat("MasterVolume", -80);
        }
        else
        {
            mixer.SetFloat("MasterVolume", lastVolume);
        }
    }

    public void ButtonSound()
    {
        fxSource.PlayOneShot(clickSound);
    }

    public void PlayGame()
    {
        ButtonSound();
        Time.timeScale = 1f; // Reanudar el juego
        //playerController.StartGame(); // Iniciar el juego en el PlayerController
        //cameraFollow.StartGame(); // Iniciar el juego en el CameraFollow
        mainPanel.SetActive(false); // Ocultar el mainPanel
        // Si quieres cargar otra escena, descomenta la siguiente línea y comenta las dos líneas anteriores.
        // SceneManager.LoadScene("SchoolScene");
    }
}


/*public void PlayLevel(string levelName)
    {
        ButtonSound();
        SceneManager.LoadScene(levelName);
    }*/
