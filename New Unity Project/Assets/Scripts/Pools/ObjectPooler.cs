using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledobjects;


    // loading sırasında platform havuzunu dolduruyor
    void Start()
    {
        pooledobjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }
        
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledobjects.Count; i++)
        {
            if (!pooledobjects[i].activeInHierarchy)
            {
                return pooledobjects[i];
            }
        }
        // havuzdaki objeler yeterli olmazsa yeni obje oluşturuyor
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledobjects.Add(obj);
        return obj;
    }
}
