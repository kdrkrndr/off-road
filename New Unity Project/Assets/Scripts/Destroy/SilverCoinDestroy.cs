using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoinDestroy : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSFX;
    private GameObject destructionPoint;


    public AudioClip ButtonClickSFX { get => buttonClickSFX; set => buttonClickSFX = value; }

    private void Start()
    {
        //DestructionPoint'ı bulmasını sağlıyoruz
        destructionPoint = GameObject.Find("DestructionPoint");
    }

    private void Update()
    {
        DestroyPassedCoin();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Player" )
            {
                gameObject.SetActive(false);
                AudioManager.Instance.PlaySFX(buttonClickSFX, 0.5f);
                GamePlayControl.instance.IncrementScoreSilver();
            }            
    }

    private void DestroyPassedCoin()
    {
        //Silver taglı game objecti _coin' refererans edip eğer destructionPoint'ın gerisinde kalışsa kaldırıyoruz
        GameObject _coin = GameObject.FindWithTag("Silver");
         if (_coin.transform.position.x < destructionPoint.transform.position.x)
         {
            gameObject.SetActive(false);
         }

    }
}
