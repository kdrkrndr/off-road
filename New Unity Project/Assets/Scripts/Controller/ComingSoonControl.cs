using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComingSoonControl : MonoBehaviour
{
    [SerializeField] private AudioClip SoundButtonSFX;
    public void BackToMenu()
    {
        SceneManager.LoadScene("Car Select Menu");
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
    }
}
