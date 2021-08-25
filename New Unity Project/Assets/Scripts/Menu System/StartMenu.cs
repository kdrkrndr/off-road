using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private AudioClip menuSelectSFX;

    private void Start()
    {
        AudioManager.Instance.SetMusicVolume(0.1f);

    }
    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX(menuSelectSFX, 2f);
        // GameManager.instance.playerDiedGameRestart = false;
        SceneManager.LoadScene("Car Select Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
