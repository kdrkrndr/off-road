using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public TMP_Text SounOnText;
    public TMP_Text SounOffText;
    public TMP_Text SFX_OnText;
    public TMP_Text SFX_OffText;
    public static bool sounIsOn = false;
    public static bool SFX_IsOn = false;
    public GameObject SettingsCanvas;
    public GameObject pauseMenuUI;

    [SerializeField] private AudioClip SoundButtonSFX;

    private void Start()
    {
        SounOnText.GetComponent<TMP_Text>().enabled = true;
        SFX_OnText.GetComponent<TMP_Text>().enabled = true;
        SounOffText.GetComponent<TMP_Text>().enabled = false;
        SFX_OffText.GetComponent<TMP_Text>().enabled = false;
    }

    public void MusicButton()
    {
        if (sounIsOn)
        {
            AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
            SounOn();
        }
        else
        {
            AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
            SoundOff();
        }
    }
    public void SFX_Button()
    {
        if (SFX_IsOn)
        {
            AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
            SFX_On();
        }
        else
        {
            AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
            SFX_Off();
        }
    }

     void SounOn()
    {
        AudioManager.Instance.SetMusicVolume(0.1f);
        SounOnText.GetComponent<TMP_Text>().enabled = true;
        SounOffText.GetComponent<TMP_Text>().enabled = false;
        sounIsOn= false;
    }
     void SoundOff()
    {
        AudioManager.Instance.SetMusicVolume(0);
        SounOnText.GetComponent<TMP_Text>().enabled = false;
        SounOffText.GetComponent<TMP_Text>().enabled = true;
        sounIsOn = true;
    }
     void SFX_On()
    {
        AudioManager.Instance.SetSFXVolume(0.5f);
        SFX_OnText.GetComponent<TMP_Text>().enabled = true;
        SFX_OffText.GetComponent<TMP_Text>().enabled = false;
        SFX_IsOn = false;
    }
     void SFX_Off()
    {
        AudioManager.Instance.SetSFXVolume(0);
        SFX_OnText.GetComponent<TMP_Text>().enabled = false;
        SFX_OffText.GetComponent<TMP_Text>().enabled = true;
        SFX_IsOn = true;
    }
    public void BackToPauseMenu()
    {
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
        SettingsCanvas.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //oyunu durduruyor
    }
    public void Info()
    {
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
        Application.OpenURL("www.google.com");
    }
}
