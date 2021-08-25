using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music1;

    void Start()
    {
        AudioManager.Instance.PlayMusic(music1);
    }


    void Update()
    {
        
    }
}
