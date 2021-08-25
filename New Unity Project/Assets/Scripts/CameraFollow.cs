using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private int _index;
    private GameObject tempTar;

    void Start()
    {
        //aktif arabanın takip edilmesini sağlıyor.
        //bool cp = GetComponent<CarCheck>().activated;
        //if (cp==true)
        //{
        //_index= FindObjectOfType<CarSelectionMenu>().carIndex;        

        //}        
    }

    void FixedUpdate()
    {
        target = FindObjectOfType<CarCheck>().carTransform;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed /** Time.deltaTime*/);
        transform.position = smoothedPosition;
    }
}
