using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSystem : MonoBehaviour
{

    [Header("Dust Properties")]
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] ParticleSystem dust = null;

    private GameObject player;

    CarController hiz;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hiz = gameObject.GetComponent<CarController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hiz.currentSpeed > 35f)
        {
            Debug.Log("hız: " + hiz.currentSpeed);
            Toz();
        }
    }

    public void Toz() //arabanın zemin kontrolünü yapıyor
    {

        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 10f, 1 << LayerMask.NameToLayer("kuruzemin"));

        Debug.Log(hit.collider);
        //Color rayColor;
        // If it hits something...
        if (hit.collider != null)
        {
            //rayColor = Color.green;
            dust.Play();
            //toz.loop ^= true;
            Debug.Log("Tozzz");
        }
        else
        {
            //rayColor = Color.red;
            dust.Pause();
            //toz.loop ^= false;
        }
    }
}
