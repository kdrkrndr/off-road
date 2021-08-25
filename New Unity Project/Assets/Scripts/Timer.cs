using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public static Timer timerinstance;
                                    //car gameobject lerinin içinde
    public TMP_Text timerText;
    private float startTime;
    [HideInInspector] // Hides var below
    public string minutes;
    [HideInInspector] // Hides var below
    public string seconds;
    [HideInInspector] // Hides var below
    public float t;

    void Start()
    {
        startTime = Time.time;
    }
    
    void Update()
    {
        t = Time.time - startTime;
        minutes = (((int)t / 60)<10)? "0"+ ((int)t / 60): ((int)t / 60).ToString();// 2 digit göstermek için
        seconds = (((int)(t % 60))<10)? "0"+ (int)(t % 60) : (t % 60).ToString("f0");//2 haneyi alıyor
        timerText.text = minutes + ":" + seconds;
    }

    #region

    #endregion
}
