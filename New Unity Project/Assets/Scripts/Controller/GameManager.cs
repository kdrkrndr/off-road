using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject player;
    private float resetTimer = 0;
    public float resetTime = 5;
    private int score;
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    
    [SerializeField] public AudioClip music2;
    
    private void Start()
    {
        RaceMusic();
        SoundOffButton.SetActive(false);
        SoundOnButton.SetActive(true);
    }

    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CarFlipped();
    }

    public void CarFlipped()
    {
        if (player.transform.localEulerAngles.z > 80 && player.transform.localEulerAngles.z < 280) // z eksenindeki dönme açısı 80 il 280 arasında ise spawn süresini başlatır

        {
            // your game has ended, you are fairly inverted
            
            resetTimer += Time.deltaTime;
        }
        else
            resetTimer = 0;

        if (resetTimer > resetTime)// süre dolunca spawn çalışır
        {
            Spawn();
        }
    }

    private void Spawn()
    {
            player.transform.rotation = Quaternion.LookRotation(transform.forward);//aynı yerde spawn ettiğimiz için sadece rotation yaptık
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 10f, 1 << LayerMask.NameToLayer("ground"));

            Vector3 spawn_point = new Vector3(player.transform.position.x, hit.point.y + 2f, 0);
            player.transform.position = spawn_point;

    }    

    public void RaceMusic()
    {
        AudioManager.Instance.SetMusicVolume(0.1f);
        AudioManager.Instance.PlayMusic(music2);
    }

    public void SoundOn()
    {
        AudioManager.Instance.SetMusicVolume(0f);
        AudioManager.Instance.SetSFXVolume(0f);
        CarController.instance.source.volume = 0f;
        SoundOffButton.SetActive(true);
        SoundOnButton.SetActive(false);

    }

    public void SoundOff()
    {
        AudioManager.Instance.SetMusicVolume(0.1f);
        AudioManager.Instance.SetSFXVolume(0.5f);
        CarController.instance.source.volume = 0.5f;
        SoundOnButton.SetActive(true);
        SoundOffButton.SetActive(false);
    }
}



