using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustSystem : MonoBehaviour
{
    
    //[SerializeField] ParticleSystem ps = null;
    ParticleSystem.MainModule main = new ParticleSystem.MainModule();

    [Header("Vehicle Properties")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxAcceleration;

    [Header("Ps Properties")]
    [SerializeField] private float sizeAcceleration = 150f;
    [SerializeField] private float lifeAcceleration = 150f;
    [SerializeField] private float sizeVelocity = 15f;
    [SerializeField] private float lifeVelocity = 15f;


    [Header("Dust Properties")]
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] ParticleSystem dust=null;


    private float velocityFinal = -1f;
    private float velocity = -1f;

    private Vector3 pos = new Vector3();
    private Vector3 posLast = new Vector3();

    private GameObject player;
    //private GameObject dust;
    //float extraYukseklik = 1f;

    CarController hiz;


    void Start()
    {
        main = dust.main;
        player = GameObject.FindGameObjectWithTag("Player");
        //dust = ParticleSystem. //GameObject.FindGameObjectWithTag("Dust");
        //dust.SetActive(false);
        //dust= GetComponent<ParticleSystem>();
        hiz= gameObject.GetComponent<CarController>();

    }

    
    void Update()
    {
       
        if (hiz.currentSpeed > 35f)
        {
             Debug.Log("hız: " + hiz.currentSpeed);
            Toz();
        }
        

        posLast = pos;
        pos = transform.position;

        velocity = velocityFinal;
        velocityFinal = (pos - posLast).magnitude / Time.deltaTime;

        float velocityPrcnt = velocityFinal / maxSpeed;
        float acceleration = (velocityFinal - velocity) / Time.deltaTime;
        float absAccPrct = Mathf.Abs(acceleration / maxAcceleration);

        ShowVehicleEffort(velocityPrcnt, absAccPrct);
        //dust = GameObject.FindGameObjectWithTag("Dust");

    }

    
    private void ShowVehicleEffort(float vMod, float aMod)
    {
        if (aMod>.2f)
        {
            main.startSize = sizeAcceleration + aMod;
            main.startLifetime = lifeAcceleration + aMod;
            Debug.Log("aMod: "+aMod);
        }
        else
        {
            main.startSize = sizeVelocity + vMod;
            main.startLifetime = lifeVelocity + vMod;
        }
    }

    public void Toz() //arabanın zemin kontrolünü yapıyor
    {

        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, 10f, 1 << LayerMask.NameToLayer("kuruzemin"));
        
        Debug.Log(hit.collider);
        Color rayColor;
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
