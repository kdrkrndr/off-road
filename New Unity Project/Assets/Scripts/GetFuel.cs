using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFuel : MonoBehaviour
{
    [HideInInspector] // Hides var below
    public CarController car;
    float currentFuel;
    [SerializeField] private AudioClip fuelSFX;

    private void Start()
    {
        car = FindObjectOfType<CarController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fuel")
        {
            AudioManager.Instance.PlaySFX(fuelSFX, 0.5f);
            currentFuel = car.fuelBar.value;
            car.fuel = 1; /*Mathf.Lerp(currentFuel, 1, 0.1f); // yavaşça dolmasını istiyorum*/ 
        }
    }

}
