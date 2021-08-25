using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GamePlayControl : MonoBehaviour
{
    public static GamePlayControl instance;
    private Text scoreText;
    private int score;
    private int levelStarsNum;
    public int levelIndex;


    public int Score { get => score; set => score = value; }

    private void Awake()
    {
        MakeInstance();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    private void Start()
    {
       
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }    

    public void IncrementScoreBronze()
    {
            score+=1;
            scoreText.text =score.ToString();

        PlayerPrefs.SetInt("coinNum", score);
    }
    public void IncrementScoreSilver()
    {
            score += 5;
            scoreText.text = score.ToString();
        PlayerPrefs.SetInt("coinNum", score);

    }
    public void IncrementScoreGold()
    {
            score += 10;
            scoreText.text = score.ToString();
        PlayerPrefs.SetInt("coinNum", score);
    }

    public void IncrementStar1()
    {
        Debug.Log("IncrementStar1() çalıştı");
        levelStarsNum = 1;
        //only your stars number is greater than the record, you can save the new record
        if (levelStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))// KEY: Lv1, Value: Stars Number
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, levelStarsNum);
        }
    }
    public void IncrementStar2()
    {
        Debug.Log("IncrementStar2() çalıştı");
        levelStarsNum = 2;
        //only your stars number is greater than the record, you can save the new record
        if (levelStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))// KEY: Lv1, Value: Stars Number
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, levelStarsNum);
            Debug.Log("Level İndex :" + levelIndex);
            Debug.Log("Level Star Num :" + levelStarsNum);
            Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex));
        }
    }
    public void IncrementStar3()
    {
        Debug.Log("IncrementStar3() çalıştı");
        Debug.Log("Level İndex :" + levelIndex);
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex));
        levelStarsNum = 3;
        //only your stars number is greater than the record, you can save the new record
        if (levelStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))// KEY: Lv1, Value: Stars Number
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, levelStarsNum);

            Debug.Log("Level Star Num :" + levelStarsNum);

        }
    }
}
