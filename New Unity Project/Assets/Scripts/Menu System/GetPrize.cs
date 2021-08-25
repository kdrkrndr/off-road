using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetPrize : MonoBehaviour
{
    private float finishTime;
    private int diamond;
    public TMP_Text diamondText;
    public Text UIdiamondText;
    public TMP_Text starText;
    private float startTime;
    private int star;
    public float time1;
    public float time2;
    public float time3;

    [SerializeField] private AudioClip WinSFX;

    public GameObject winPanel;
    public GameObject[] stars;


    public int Diamond { get => diamond; set => diamond = value; }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        finishTime = Time.time - startTime;
        //Debug.Log(" getprize finish time" + finishTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LevelFinish")
        {
            TakeDiamondPrize();
            TakeStarPrize();
            StartCoroutine(ShowStarCo()); // yıldız efektini coroutini ni çalıştırıyor
        }
    }

    #region Diamond
    public void DiamondScore()
    {
        diamond += 1;
        UIdiamondText.text = diamond.ToString();//yarış ekranındaki  diamond text
        PlayerPrefs.SetInt("diamond", diamond);
    }
    public void DiamondScore3()
    {
        diamond += 3;
        diamondText.text = diamond.ToString();
        PlayerPrefs.SetInt("diamond", diamond);
    }
    public void DiamondScore5()
    {
        diamond += 5;
        diamondText.text = diamond.ToString();
        PlayerPrefs.SetInt("diamond", diamond);
    }
    public void DiamondScore8()
    {
        diamond += 8;
        diamondText.text = diamond.ToString();
        PlayerPrefs.SetInt("diamond", diamond);
    }
    public void DiamondScore15()
    {
        diamond += 15;
        diamondText.text = diamond.ToString();//Finish ekranındaki diamond text
        PlayerPrefs.SetInt("diamond", diamond);
    }
    public void TakeDiamondPrize()
    {

        if (finishTime < time1)
        {
            AudioManager.Instance.PlaySFX(WinSFX, 0.5f);
            DiamondScore15();

        }
        else if (time1 < finishTime && finishTime < time2)
        {
            AudioManager.Instance.PlaySFX(WinSFX, 0.5f);
            DiamondScore8();

        }
        else if (time2 < finishTime && finishTime < time3)
        {
            AudioManager.Instance.PlaySFX(WinSFX, 0.5f);
            DiamondScore5();

        }
        else if (time3 < finishTime)
        {
            AudioManager.Instance.PlaySFX(WinSFX, 0.5f);
            DiamondScore3();

        }

    }
    #endregion

    #region Star
    public void StarScore1()
    {
        star = 1;
        starText.text = star.ToString();
        GamePlayControl.instance.IncrementStar1();        
    }
    public void StarScore2()
    {
        star = 2;
        starText.text = star.ToString();
        GamePlayControl.instance.IncrementStar2();
    }
    public void StarScore3()
    {
        star = 3;
        starText.text = star.ToString();
        GamePlayControl.instance.IncrementStar3();
        Debug.Log("StarScore3() çalıştı");
    }
    public void TakeStarPrize()
    {
        Debug.Log("TakeStarPrize");
        if (finishTime < time1)
        {
            StarScore3();
            Debug.Log("StarScore3");
        }
        else if (time1 < finishTime && finishTime < time2)
        {
            StarScore2();
            Debug.Log("StarScore2");
        }
        else if (time2 < finishTime && finishTime < time3)
        {
            StarScore1();
            Debug.Log("StarScore1");
        }
    }
    #endregion

    IEnumerator ShowStarCo()
    {
        winPanel.SetActive(true);
                
        if (finishTime < time1)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.5f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.5f); 
            stars[2].SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }
        else if (time1 < finishTime && finishTime < time2)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.5f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }
        else if (time2 < finishTime && finishTime < time3)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }

    }
}
