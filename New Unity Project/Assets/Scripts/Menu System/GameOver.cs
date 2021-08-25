using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    public static bool gameisOver = false;
    public GameObject gameOverMenuUI;
    public GameObject UICanvasMenu;
    private GameObject SoundOffButton;
    
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip LoseSFX;
    [SerializeField] private AudioClip GoMenuButtonSFX;


    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        MakeSingleton();
    }

    public void OyunuBitir()
    {
        

        AudioManager.Instance.PlaySFX(LoseSFX, 1f);
        gameOverMenuUI.SetActive(true);
        UICanvasMenu.SetActive(false);
        Time.timeScale = 0f; // 0 olunca oyunu durduruyor       
        gameisOver = true;
        CarController.instance.source.mute = true;
        AudioManager.Instance.SetMusicVolume(0.1f);
        AudioManager.Instance.PlayMusic(music1);
    }

    public void NewGame()
    {
        AudioManager.Instance.PlaySFX(GoMenuButtonSFX, 1f);
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameisOver = false;
        ReklamScript.InsterstitialGoster();
    }

    public void BackToGarage()
    {
        AudioManager.Instance.PlaySFX(GoMenuButtonSFX, 1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Car Select Menu");
        ReklamScript.InsterstitialGoster();
        GameObject SoundOffButton = GameObject.Find("VolumeOffButton");
        if (SoundOffButton !=null && SoundOffButton.activeInHierarchy == true)
        {
            AudioManager.Instance.SetMusicVolume(0.1f);
            AudioManager.Instance.SetSFXVolume(0.5f);
            CarController.instance.source.volume = 0.5f;
        }
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX(GoMenuButtonSFX, 1f);
        Application.Quit();
    }
}
