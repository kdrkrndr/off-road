using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHadler : MonoBehaviour
{
    public int carIndex;



    private void Awake()
    {
        //GameObject.DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        carIndex = 1;
    }

    void Update()
    {
        
    }

    public void SelectCar(int a)//car select menusünden seçilen arabanın carindex ini tutuyor
    {
        carIndex = a;
        PlayerPrefs.SetInt("carindex", a);
    }
}
