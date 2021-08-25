using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    public GameObject Garage;
    public bool isUnlocked = false;
    private GamePlayControl countStar;
    private int remainder;
    private int remainderd;
    public Image lockImage;//lock image
    public TMP_Text carCoinText;
    public TMP_Text diamondText;
    public int carPrice = 50;
    public int diamondPrice = 0;
    public int carIndexNum;


    [SerializeField] private AudioClip menuSelectSFX;
    [SerializeField] private AudioClip menuUnSelectSFX;
    [SerializeField] private AudioClip notBuySFX;
    [SerializeField] private AudioClip BuySFX;


    private void Start()
    {
        //carCoinText.text = carPrice.ToString();
        CarsOwned();
    }

    private void Update()
    {
        UpdateNewCarButton();
    }

    public void UnlockNewCar()
    {

        if (PlayerPrefs.GetInt("totalCoinNum") >= carPrice&& PlayerPrefs.GetInt("totalDiaNum") >= diamondPrice)
        {
            isUnlocked = true;
            remainder = PlayerPrefs.GetInt("totalCoinNum") - carPrice;
            PlayerPrefs.SetInt("totalCoinNum", remainder);
            remainderd = PlayerPrefs.GetInt("totalDiaNum") - diamondPrice;
            PlayerPrefs.SetInt("totalDiaNum", remainderd);
            PlayerPrefs.SetInt("Car"+ carIndexNum, 1);
            AudioManager.Instance.PlaySFX(BuySFX, 1f);
        }
        else
        {
            AudioManager.Instance.PlaySFX(notBuySFX, 1f);
        }
    }

    private void UpdateNewCarButton()
    {
        if (isUnlocked)
        {
            lockImage.gameObject.SetActive(false);
            //starsImages[i].gameObject.SetActive(true);
        }
        else
        {
            //lockImage.gameObject.SetActive(true);
            //starsImages[i].gameObject.SetActive(false);
        }
    }

    public void SceneTransition(string _sceneName)
    {
        if (isUnlocked == true)
        {
            AudioManager.Instance.PlaySFX(menuSelectSFX, 1f);
            SceneManager.LoadScene(_sceneName);//car (num) inspector de buttton Script onclick event da seçili olan _sceneName
            Garage.gameObject.SetActive(false);//carSelectionPanel'i disable yapıyoruz               
        }
        else
        {
            AudioManager.Instance.PlaySFX(menuUnSelectSFX, 1f);
            Debug.Log("You don't have this car!");
        }
    }

    public static bool GetBool(string name) //playerPrefs ile gelen değeri bool türüne conver ediyor
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }

    private void CarsOwned()
    {
        if (PlayerPrefs.GetInt("Car" + carIndexNum) == 1)
        {
            isUnlocked = GetBool("Car" + carIndexNum);     
         
        }
        else
        {

        }
    }
}
