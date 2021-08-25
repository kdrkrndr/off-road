using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class ShopControl : MonoBehaviour
{
    public static ShopControl instance;
    int coinAmount;
    int diamontAmount;
    public TMP_Text coinText;
    public TMP_Text diamondText;
    private int oduls = 0;
    public Button buyCoinButton;
    public Button buyDiamondButton;
    public Button freeDiamonButton;
    [SerializeField] private AudioClip SoundButtonSFX;

    private void Awake()
    {
        // ShopControl script'i, instance değişkenine değer olarak kendisini (this) veriyor
        instance = this;
    }
    private void Start()
    {
        coinAmount = PlayerPrefs.GetInt("totalCoinNum");
        diamontAmount = PlayerPrefs.GetInt("totalDiaNum");
        freeDiamonButton.interactable=true;
    }

    private void Update()
    {
        coinText.text = coinAmount.ToString();
        diamondText.text = diamontAmount.ToString();

        if (coinAmount >= 100 )
            buyDiamondButton.interactable = true;
        else
            buyDiamondButton.interactable = false;

        if (diamontAmount >= 8)
            buyCoinButton.interactable = true;
        else
            buyCoinButton.interactable = false;
        diamondText.text = PlayerPrefs.GetInt("totalDiaNum").ToString();
    }

    public void buyDiamond()
    {
        coinAmount -= 25;
        diamontAmount += 2;
        coinText.text = coinAmount.ToString();
        diamondText.text = diamontAmount.ToString();
        PlayerPrefs.SetInt("totalCoinNum", coinAmount);
        PlayerPrefs.SetInt("totalDiaNum", diamontAmount);
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
    }

    public void buyCoin()
    {
        diamontAmount -= 8;
        coinAmount += 100;
        coinText.text = coinAmount.ToString();
        diamondText.text = diamontAmount.ToString();
        PlayerPrefs.SetInt("totalDiaNum", diamontAmount);
        PlayerPrefs.SetInt("totalCoinNum", coinAmount);
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
    }

    public void exitShop()
    {
        SceneManager.LoadScene("Car Select Menu");
        AudioManager.Instance.PlaySFX(SoundButtonSFX, 1f);
    }

    public void WatchForDiamond()
    {
        ReklamScript.RewardedReklamGoster();
        //oduls += 5 + diamontAmount;
        //Debug.Log("ödül: " + oduls);
        //PlayerPrefs.SetInt("totalDiaNum", oduls);
        //oduls = 0;
        //freeDiamonButton.interactable = false;
    }
    public void Reward()
    {
        oduls += 5 + diamontAmount;
        Debug.Log("ödül: " + oduls);
        PlayerPrefs.SetInt("totalDiaNum", oduls);
        oduls = 0;
        freeDiamonButton.interactable = false;
    }


    //void (GoogleMobileAds.Api.Reward odul)
    //{
    //    Debug.Log(" ödül :" + odul.Type + odul.Amount);

    //}


    //public void WatchForCoin()
    //{
    //    ReklamScript.RewardedReklamGoster(RewardedReklamGosterildiCoin);
    //}

    //void RewardedReklamGosterildiCoin(GoogleMobileAds.Api.Reward odul)
    //{
    //    oduls += (int)odul.Amount + 23 + coinAmount;
    //    Debug.Log("ödüllllllllllllll aldım: "+odul.Amount);
    //    PlayerPrefs.SetInt("totalCoinNum", oduls);
    //    coinText.text = oduls.ToString();
    //}
}
