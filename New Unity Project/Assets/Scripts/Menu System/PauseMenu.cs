using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject UICanvas;
    public GameObject SoundOffButton;

    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip pauseButtonSFX;
    [SerializeField] private AudioClip pauseMenuButtonSFX;
     
    public void PauseButton()
    {
        if (GameisPaused)
        {
            AudioManager.Instance.PlaySFX(pauseButtonSFX, 1f);
            Resume();
        }
        else
        {
            AudioManager.Instance.PlaySFX(pauseButtonSFX, 1f);
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        UICanvas.SetActive(true);
        Time.timeScale = 1f; // oyunu devam ettiriyor
        GameisPaused = false;
        CarController.instance.source.mute = false;
        AudioManager.Instance.SetMusicVolume(0.1f);
        AudioManager.Instance.PlayMusic(FindObjectOfType<GameManager>().music2);
        if (SoundOffButton.activeInHierarchy == true)
        {
            AudioManager.Instance.SetMusicVolume(0f);
            AudioManager.Instance.SetSFXVolume(0f);
            CarController.instance.source.volume = 0f;
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        UICanvas.SetActive(false);
        Time.timeScale = 0f; //oyunu durduruyor
        GameisPaused = true;
        CarController.instance.source.mute = true;
        AudioManager.Instance.SetMusicVolume(0.1f);
        AudioManager.Instance.PlayMusic(music1);
    }

    public void NewGame()
    {
        AudioManager.Instance.PlaySFX(pauseMenuButtonSFX, 0.5f);
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);       
        GameisPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ReklamScript.InsterstitialGoster();
    }

    public void BackToGarage()
    {
        AudioManager.Instance.PlaySFX(pauseMenuButtonSFX, 0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Car Select Menu");
        PlayerPrefs.DeleteKey("carindex");
        ReklamScript.InsterstitialGoster();
        if (SoundOffButton.activeInHierarchy==true)
        {
            AudioManager.Instance.SetMusicVolume(0.1f);
            AudioManager.Instance.SetSFXVolume(0.5f);
            CarController.instance.source.volume = 0.5f;
        }
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX(pauseMenuButtonSFX, 0.5f);
        Application.Quit();
    }
}
