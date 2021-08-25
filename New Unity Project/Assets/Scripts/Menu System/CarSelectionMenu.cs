using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CarSelectionMenu : MonoBehaviour
{
    public static CarSelectionMenu carinstance;

    private int coinScore = 0;
    private int diamondScore = 0;
    public GameObject GarageCanvas;
    public GameObject SettingsCanvas;
    public TMP_Text coinScoreText;
    public TMP_Text diamondScoreText;
    private int totalScore;
    private int totalScored;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip SoundButtonSFX;



    private void Awake()
    {
        if (carinstance == null)
        {
            carinstance = this;
        }
        else
        {
            if (carinstance != null)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        AudioManager.Instance.SetMusicVolume(0.1f);
        AudioManager.Instance.PlayMusicWithFade(music1);
    }

    private void Update()
    {
        UpdateCoinScore();
        UpdateDiamondScore();
    }

    public void UpdateCoinScore()
    {
        coinScore = PlayerPrefs.GetInt("coinNum");
        totalScore = PlayerPrefs.GetInt("totalCoinNum"); // totalCoinNum anahtarıyla kaydedilmiş veriyi getir
        totalScore += coinScore;
        PlayerPrefs.SetInt("totalCoinNum", totalScore);
        if (PlayerPrefs.HasKey("totalCoinNum"))  //totalCoinNum anahtarıyla kaydedilmiş bir veri var mı ?
        {
            coinScoreText.text = totalScore.ToString();
        }
        PlayerPrefs.DeleteKey("coinNum");
        ////Debug.Log("current Coin=" + totalScore);

    }

    public void UpdateDiamondScore()
    {
        diamondScore = PlayerPrefs.GetInt("diamond");
        totalScored = PlayerPrefs.GetInt("totalDiaNum"); // totalDiaNum anahtarıyla kaydedilmiş veriyi getir
        totalScored += diamondScore;
        PlayerPrefs.SetInt("totalDiaNum", totalScored);
        if (PlayerPrefs.HasKey("totalDiaNum"))  //totalDiaNum anahtarıyla kaydedilmiş bir veri var mı ?
        {
            diamondScoreText.text = totalScored.ToString();
        }
        PlayerPrefs.DeleteKey("diamond");
        ////Debug.Log("current Coin=" + totalScore);

    }

    public void goToShop()
    {
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
        SceneManager.LoadScene("Shop");
    }

    public void Exit()
    {
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
        Application.Quit();
    }
}

