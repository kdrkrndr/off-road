using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    public GameObject destructionPoint;


    void Start()
    {
        destructionPoint = GameObject.Find("DestructionPoint");
    }


    void Update()
    {
        //objenin x konumu destructionPoint in x numdan küçkse false yap
        if (transform.position.x < destructionPoint.transform.position.x)
        {            
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
