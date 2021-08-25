using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public static CarController instance;

    [Header("Drive System")]
    public int AddSpeed;
    public int MaxSpeed;
    public int MaxBackSpeed;
    public int MotorTorque = 1000 ;
    public HingeJoint2D[] wheels = new HingeJoint2D[2];
    public JointMotor2D Motor;
    public float currentSpeed;
    public int[] gearRatio;
    public int currentGear;
    public static bool isRaceBtnDown;
    public static bool isBrakeBtnDown;
    private GameObject egzoz;
    ParticleSystem duman;
    [HideInInspector]
    public AudioSource source;
    public GameObject finishing;
    [SerializeField] private AudioClip carStopSFX;
    [SerializeField] private AudioClip carStartSFX;
    //public GameObject mudParticle;
    

    [Header("Brake System")]
    public bool isBraking = false;
    public float maxBrakeTorque = 150f;
    public GameObject behindPoint;
    public GameObject dropPoint;

    [Header("Fuel System")]
    public float fuel = 1f;
    public float fuelConsumption = 0.1f;
    public Slider fuelBar;
    public Color fullColor;
    public Color lowColor;
    private float consumptionMultiple;
    private bool once=false;


    [Header("Distance System")]
    public Slider distanceSlider;
    public GameObject finisPoint;
    private float distance;
    private GameObject car;
    private float startPointx;

    void Awake()
    {
        // Player script'i, instance değişkenine değer olarak kendisini (this) veriyor
        instance = this;
        AudioManager.Instance.PlaySFX(carStartSFX);
    }

    void Start()
    {
        source = GetComponent<AudioSource>();        
        startPointx = transform.position.x;
        isRaceBtnDown = false;
        isBrakeBtnDown = false;
        //mudParticle.SetActive(false);
        egzoz = GameObject.Find("EgzozDuman");

    }

    void Update()
    {
        Movement();
        FuelConsumption();
        EngineSound();
        EngineStop();
        currentSpeed = Motor.motorSpeed;
        Distance();
    }

    public void Movement()
    {        
        if (fuel> 0 )
        {
            if (isRaceBtnDown==true && Motor.motorSpeed < MaxSpeed-5) //gas
            {
                Motor.motorSpeed = (Motor.motorSpeed + AddSpeed*2) + Time.deltaTime;
                Motor.maxMotorTorque = MotorTorque;
                wheels[0].motor = Motor;
                wheels[1].motor = Motor;                
            }
             else if (isBrakeBtnDown == true && Motor.motorSpeed > MaxBackSpeed && dropPoint.transform.position.x <= behindPoint.transform.position.x) //brake
            {
                Motor.motorSpeed = (Motor.motorSpeed - AddSpeed) - Time.deltaTime;
                Motor.maxMotorTorque = MotorTorque;
                wheels[0].motor = Motor;
                wheels[1].motor = Motor;
            }

            else
            {
                if (Motor.motorSpeed > 0)
                {
                    Motor.motorSpeed = (Motor.motorSpeed - AddSpeed/4) - (Time.deltaTime);
                    wheels[0].motor = Motor;
                    wheels[1].motor = Motor;
                }
                else if (Motor.motorSpeed < 0)
                {
                    Motor.motorSpeed = (Motor.motorSpeed + AddSpeed) + (Time.deltaTime);
                    wheels[0].motor = Motor;
                    wheels[1].motor = Motor;
                }
            }
        }
        else
        {
            Motor.motorSpeed = 0;
            Motor.maxMotorTorque = 10;
            wheels[0].motor = Motor;
            wheels[1].motor = Motor;
        }
    }

    #region Movement Button Control
    public void RaceBtnDown()
    {
        isRaceBtnDown = true;
        ActivateMud();
        //Debug.Log("Race Button Down");
    }
    public void RaceBtnUp()
    {
        isRaceBtnDown = false;
        //Debug.Log("Race Button Up");
    }
    public void BrakeBtnDown()
    {
        isBrakeBtnDown = true;
        //Debug.Log("Brake Button Down");
    }
    public void BrakeBtnUp()
    {
        isBrakeBtnDown = false;
        //Debug.Log("Brake Button Up");
    }
    #endregion

    public void FuelConsumption()
    {
        if (isRaceBtnDown == true)
        {
            consumptionMultiple = 0.5f;
            fuel -= fuelConsumption * consumptionMultiple * Time.deltaTime;
        }
        else if (isBrakeBtnDown == true)
        {
            consumptionMultiple = 0.3f;
            fuel -= fuelConsumption * consumptionMultiple * Time.deltaTime;
        }
        else
        {
            consumptionMultiple = 0.01f;
            fuel -= fuelConsumption * consumptionMultiple * Time.deltaTime;
        }

        fuelBar.value = fuel;

        var fill = (fuelBar as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>()
            .FirstOrDefault(t => t.name == "Fill");
        if (fill != null)
        {
            fill.color = Color.Lerp(lowColor, fullColor, fuel);
        }

    }

    private void EngineSound()
    {
        float minGear;
        float maxGear;
        float pitchEngine=1;
        int k;
        k = gearRatio.Length;
       

        for (int i = 0; i < k; i++)
        {

            if (gearRatio[i] > currentSpeed)
            {
                currentGear = i;
                //Debug.Log("Gear " + currentGear);
                //Debug.Log("Speed " + currentSpeed);
                break;
            }

            if (i == 0)
            {
                minGear = 0;
                maxGear = 0;
            }
            else
            {
                minGear = gearRatio[i - 1];
                maxGear = gearRatio[i];
                pitchEngine = (currentSpeed - minGear) / (maxGear - minGear);

            }
            source.pitch = pitchEngine;

                        
        }      
    }

    public void EngineStop()
    {

        if (fuel <= 0)
        {
            // This returns the GameObject named LevelFinishMenu.
            finishing = GameObject.Find("LevelFinishMenu");
            if (!finishing.activeSelf)//eğer oyun finish çizgisini geçerek bittiyse yakıt bitince OyunuBitir()
                                        //çalıştırılmıyor ve game over yazısının çıkmasından kurtuluyoruz
            {
                if (!once)//update içerisinde sadece birkez çağırılmasını sağlıyoruz.
            {
                source.volume = 0.1f;
                AudioManager.Instance.PlaySFX(carStopSFX, 0.1f);
                source.mute = true;
                once = true;
                GameObject go = GameObject.Find("GameOverMenu");
                GameOver other = (GameOver)go.GetComponent(typeof(GameOver));
                other.OyunuBitir();
            }
            }

        }
    }

    public void Distance()
    {
        distance = 1-(finisPoint.transform.position.x - transform.position.x)/(finisPoint.transform.position.x-startPointx);
        distanceSlider.value = distance;
        //Debug.Log(transform.position.x - startPointx);
    }

    public void ActivateMud()
    {
        //mudParticle.SetActive(true);
    }
}
