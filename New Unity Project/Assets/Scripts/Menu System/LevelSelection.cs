using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public bool isUnlocked = false;
    public Image lockImage;//lock image
    public Image[] starsImages;//empty three star images

    public Sprite[] starsSprite;

    [SerializeField] private AudioClip menuSelectSFX;
    [SerializeField] private AudioClip menuUnSelectSFX;

    private void Update()
    {
        UpdateLevelButton();
        UnlockLevel();
    }

    private void UnlockLevel()
    {
        int previousLvIndex= int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv"+previousLvIndex)>0)
        {
            isUnlocked = true;
        }
    }

    private void UpdateLevelButton() // dolu yıldızları açıp boşları kapatıyor
    {
        if (isUnlocked)
        {
            lockImage.gameObject.SetActive(false);
            for (int i = 0; i < starsImages.Length; i++)
            {
                starsImages[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < PlayerPrefs.GetInt("Lv"+gameObject.name); i++)
            {
                starsImages[i].sprite = starsSprite[i];
            }
        }
        else
        {
            lockImage.gameObject.SetActive(true);
            for (int i = 0; i < starsImages.Length; i++)
            {
                starsImages[i].gameObject.SetActive(false);
            }
        }
    }

    public void SceneTransition(string _sceneName)
    {
        if (isUnlocked)
        {
            AudioManager.Instance.PlaySFX(menuSelectSFX, 1f);
            SceneManager.LoadScene(_sceneName);
            UIManager.instance.mapSelectionPanel.gameObject.SetActive(false);//mapSelectionPanel'i disable yapıyoruz
            for (int i = 0; i < UIManager.instance.mapSelections.Length; i++)//levelSelectionPanel'leri de disable yapıyoruz
            {
                UIManager.instance.levelSelectionPanel[i].gameObject.SetActive(false);
            }
        }
        else
        {
            AudioManager.Instance.PlaySFX(menuUnSelectSFX, 1f);
            Debug.Log("We have not unlocked this level");
        }
    }

}
