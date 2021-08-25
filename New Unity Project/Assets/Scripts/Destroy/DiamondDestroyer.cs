using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondDestroyer : MonoBehaviour
{
    [SerializeField] private AudioClip diomondSFX;
    //private GameObject destructionPoint;

    //public AudioClip ButtonClickSFX { get => diomondSFX; set => diomondSFX = value; }

    private void Start()
    {
        //destructionPoint = GameObject.Find("DestructionPoint");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            AudioManager.Instance.PlaySFX(diomondSFX, 0.5f);
            FindObjectOfType<GetPrize>().DiamondScore();
        }
    }
}
