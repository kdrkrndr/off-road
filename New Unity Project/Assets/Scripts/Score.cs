using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    //LevelFinishMenu objesine ekli. finish ekranında time skorunu ve besttime i gösteriyor.

    public TMP_Text TimeScoreText;
    public TMP_Text CoinScoreText;

    //public TMP_Text BestScoreTxt;
    [HideInInspector]
    public float minutes;
    [HideInInspector]
    public int seconds;
    private int coins;
    private string minutesText;
    private string secondsText;


    void Start()
    {
        minutesText = FindObjectOfType<Timer>().minutes;
        secondsText = FindObjectOfType<Timer>().seconds;
        minutes = (int)FindObjectOfType<Timer>().t / 60;
        seconds = (int)FindObjectOfType<Timer>().t % 60;
        coins = PlayerPrefs.GetInt("coinNum");
        //BestScoreTxt.text = PlayerPrefs.GetInt("scorem", 10) + ":" + PlayerPrefs.GetInt("scores", 10);
    }

    void Update()
    {
        TimeScoreText.text = minutesText + ":" + secondsText;
        CoinScoreText.text = coins.ToString();
        //Debug.Log(minutes * 60 + seconds);

        //if (minutes*60+seconds < (PlayerPrefs.GetInt("scorem",10) * 60)+ PlayerPrefs.GetInt("scores"))
        //{     
        string m = (minutes < 10) ? "0" + minutes : minutes.ToString();
        string s = (seconds < 10) ? "0" + seconds : seconds.ToString();
        //    BestScoreTxt.text = m + ":" + s;
        //PlayerPrefs.SetInt("scorem", minutes);
        //    PlayerPrefs.SetInt("scores", seconds);
        //}

    }


}
