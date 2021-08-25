using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntranceController : MonoBehaviour
{
    [SerializeField] private AudioClip music1;


    private IEnumerator Start()//bekledikten 3 saniye sonra ana menuye geçiyor.
    {
        //AudioManager.Instance.SetMusicVolume(0.1f);
        //AudioManager.Instance.PlayMusic(music1);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Car Select Menu");
    }
}
