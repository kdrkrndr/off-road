using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject LevelFinishMenu;
    public GameObject UICanvasMenu;
    public GameObject PausePanel;
    private GameObject SoundOffButton;
    

    [SerializeField] private AudioClip winningSFX;
    [SerializeField] private AudioClip FinishMenuSFX;
    public static bool isLevelFinish = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="LevelFinish")
        {    
            OyunuBitir();
        }        
    }

    public void OyunuBitir()
    {
        LevelFinishMenu.SetActive(true);
        UICanvasMenu.SetActive(false);
        PausePanel.SetActive(false);        
        Time.timeScale = 0.5f; //oyunu yarı hızında yürütüyor
        isLevelFinish = true;
        CarController.instance.source.mute = true;
        AudioManager.Instance.SetMusicVolume(0);
    }

    public void PlayAgain()
    {
        AudioManager.Instance.PlaySFX(FinishMenuSFX, 0.5f);
        LevelFinishMenu.SetActive(false);
        UICanvasMenu.SetActive(true);
        Time.timeScale = 1f;
        AudioManager.Instance.SetMusicVolume(0.01f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ReklamScript.InsterstitialGoster();
    }

    public void BackToGarage()
    {
        AudioManager.Instance.PlaySFX(FinishMenuSFX, 0.5f);
        Time.timeScale = 1f;
        UICanvasMenu.SetActive(true);
        SceneManager.LoadScene("Car Select Menu");
        AudioManager.Instance.SetMusicVolume(0.01f);
        ReklamScript.InsterstitialGoster();
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX(FinishMenuSFX, 0.5f);
        Application.Quit();
    }       
}
