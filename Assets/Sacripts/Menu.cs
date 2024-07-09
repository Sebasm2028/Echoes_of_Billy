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

    private void Awake()
    {
        //Cuando cambia el valor del slider llama la función change 
        masterVolumen.onValueChanged.AddListener(ChangeMasterVolume);
        fxVolume.onValueChanged.AddListener(ChangeFxVolume);
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        playPanel.SetActive(false);

        panel.SetActive(true);
        ButtonSound();
    }

    //Setea los valores que el usuario desea
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
        {//si está muteado 
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
        // Cargar el primer nivel del juego directamente
        SceneManager.LoadScene("Level1");
    }

    
}

/*public void PlayLevel(string levelName)
    {
        ButtonSound();
        SceneManager.LoadScene(levelName);
    }*/
