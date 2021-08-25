using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheck : MonoBehaviour
{
    public static CarCheck instance;
    public Transform carTransform;


    // List with all car objects in the scene
    public GameObject[] cars;
    private int _carIndex;

    void Start()
    {
        ActivateCar();
    }

        // Activate the car
    public void ActivateCar()
    {        // We activate the current car
        _carIndex = PlayerPrefs.GetInt("carindex") +1;//datahandler'dan gelen carindex' göre arabayı belirliyor ve kamerayı ayarlıyor.
        switch (_carIndex)
        {
            case 1:
                cars[0].SetActive(true);                
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);

                carTransform = cars[0].transform;
                break;
           
            case 2:
                cars[0].SetActive(false);
                cars[1].SetActive(true);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[1].transform;
                break;
            case 3:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(true);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[2].transform;
                break;
            case 4:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(true);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[3].transform;
                break;
            case 5:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(true);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[4].transform;
                break;
            case 6:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(true);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[5].transform;
                break;
            case 7:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(true);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[6].transform;
                break;
            case 8:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(true);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[7].transform;
                break;
            case 9:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(true);
                cars[9].SetActive(false);
                cars[10].SetActive(false);
                carTransform = cars[8].transform;
                break;
            case 10:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(true);
                cars[10].SetActive(false);
                carTransform = cars[9].transform;
                break;
            case 11:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                cars[6].SetActive(false);
                cars[7].SetActive(false);
                cars[8].SetActive(false);
                cars[9].SetActive(false);
                cars[10].SetActive(true);
                carTransform = cars[10].transform;
                break;
            default:
                break;
        }

    }
}
