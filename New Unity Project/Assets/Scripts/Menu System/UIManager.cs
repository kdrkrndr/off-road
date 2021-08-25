using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanel;

    [SerializeField] private AudioClip menuSelectSFX;
    [SerializeField] private AudioClip menuUnSelectSFX;
    [SerializeField] private AudioClip BackMapButtonSFX;
    [SerializeField] private AudioClip BackToCarButtonSFX;

    [Header ("OUR STARS UI")]
    public int stars;
    public TMP_Text starText;
    public MapSelection[] mapSelections;
    public TMP_Text[]  questStarsTexts;
    public TMP_Text[] lockedStarsTexts;
    public TMP_Text[] unlockStarsTexts;
    
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            if (instance!=null)
            {
                Destroy(gameObject);
            }
        }
        //DontDestroyOnLoad(gameObject);
    }

    private void Update()//TODO Remove this metod because  we don't want to call these metod each frame
    {
        UpdateStarUI();
        UpdateLockedStarUI();
        UpdateUnlockedStarUI();
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    private void UpdateLockedStarUI()
    {
        for (int i = 0; i < mapSelections.Length; i++)
        {
            questStarsTexts[i].text = mapSelections[i].questNum.ToString();

            if (mapSelections[i].isUnLock==false)// if one of the map is locked
            {
                lockedStarsTexts[i].text = stars.ToString() + "/" + mapSelections[i].endLevel * 3;
            }
        }
    }

    private void UpdateUnlockedStarUI()
    {
        for (int i = 0; i < mapSelections.Length; i++)
        {
            unlockStarsTexts[i].text = stars.ToString() + "/" + mapSelections[i].endLevel * 3;
            switch (i)
            {
                case 0://MAP 01
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 1) + PlayerPrefs.GetInt("Lv" + 2)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                   break;
                case 1://MAP 02
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 3) + PlayerPrefs.GetInt("Lv" + 4) + PlayerPrefs.GetInt("Lv" + 5)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
                case 2://MAP 03
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 6) + PlayerPrefs.GetInt("Lv" + 7) + PlayerPrefs.GetInt("Lv" + 8)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
                case 3://MAP 04
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 9) + PlayerPrefs.GetInt("Lv" + 10) + PlayerPrefs.GetInt("Lv" + 11)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
            }
        }
    }

    private void UpdateStarUI()//yıldız sayılarını toplayıp saklıyor
    {
        stars = PlayerPrefs.GetInt("Lv" + 1) + PlayerPrefs.GetInt("Lv" + 2) + PlayerPrefs.GetInt("Lv" + 3) + 
            PlayerPrefs.GetInt("Lv" + 4) + PlayerPrefs.GetInt("Lv" + 5)+ PlayerPrefs.GetInt("Lv" + 6) + 
            PlayerPrefs.GetInt("Lv" + 7) + PlayerPrefs.GetInt("Lv" + 8) + PlayerPrefs.GetInt("Lv" + 9);
        starText.text = stars.ToString();
    }

    public void PressMapButton(int _mapIndex)//This metos will be triggered whwn we press the (Four) map button
    {
        if (mapSelections[_mapIndex].isUnLock==true)//you can open this map
        {
            AudioManager.Instance.PlaySFX(menuSelectSFX, 0.5f);
            levelSelectionPanel[_mapIndex].gameObject.SetActive(true);
            mapSelectionPanel.gameObject.SetActive(false);

        }
        else
        {
            AudioManager.Instance.PlaySFX(menuUnSelectSFX, 0.5f);
            Debug.Log("You can not open this map. Please work hard to collect more stars");
        }
    }

    public void BackMapButton()
    {
        AudioManager.Instance.PlaySFX(BackMapButtonSFX, 0.5f);
        mapSelectionPanel.gameObject.SetActive(true);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            levelSelectionPanel[i].gameObject.SetActive(false);
        }
    }    

    public void BackToCarButton(string _sceneName)
    {
        AudioManager.Instance.PlaySFX(BackToCarButtonSFX, 0.5f);
        SceneManager.LoadScene(_sceneName);
    }
}
