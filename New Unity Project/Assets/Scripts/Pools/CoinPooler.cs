using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPooler : MonoBehaviour
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

    public GameObject GetPooledObject1()
    {
        for (int i = 0; i < pooledobjects.Count; i++)
        {
            if (!pooledobjects[i].activeInHierarchy)
            {
                return pooledobjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledobjects.Add(obj);
        return obj;
    }

    //********************************************************

    //public static CoinPooler SharedInstance;

    //void Awake()
    //{
    //    SharedInstance = this;
    //}

    //private List<GameObject> pooledObjects;
    //public List<ObjectPoolItem> itemsToPool;


    //[System.Serializable]
    //public class ObjectPoolItem
    //{
    //    public GameObject objectToPool;
    //    public int amountToPool;
    //    public bool shouldExpand;
    //}

    //void Start()
    //{
    //    pooledObjects = new List<GameObject>();
    //    foreach (ObjectPoolItem item in itemsToPool)
    //    {
    //        for (int i = 0; i < item.amountToPool; i++)
    //        {
    //            GameObject obj = (GameObject)Instantiate(item.objectToPool);
    //            obj.SetActive(false);
    //            pooledObjects.Add(obj);
    //        }
    //    }
    //}

    //public GameObject GetPooledObject(string tag)
    //{
    //    for (int i = 0; i < pooledObjects.Count; i++)

    //    {
    //        if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
    //        {
    //            return pooledObjects[i];
    //        }
    //    }
    //    //foreach (ObjectPoolItem item in itemsToPool)
    //    //{
    //    //    if (item.objectToPool.name == name)
    //    //    {
    //    //        if (item.shouldExpand)
    //    //        {
    //    //            GameObject obj = (GameObject)Instantiate(item.objectToPool);
    //    //            obj.SetActive(false);
    //    //            pooledObjects.Add(obj);
    //    //            return obj;
    //    //        }
    //    //    }
    //    //}
    //    return null;
    //}


    //**************************************************************************************
}


//    public Vector3 spawnValues;
//    public float spawnWait;
//    public float spawnMostWait;
//    public float spawnLeastWait;
//    public int startWait;
//    public Transform generatePoint;
//    public bool stop;

//    private ObjectPooler havuz;






//    void Update()
//    {

//    }

//    IEnumerator WaiterSpawner()
//    {
//        yield return new WaitForSeconds(startWait);

//        while (!stop && transform.position.x < generatePoint.position.x)
//        {
//            Vector3 spawnPoint = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 0);

//            ////GameObject newCoins = havuz.pooledObject.gameObject.tag("GoldPool");
//            //newCoins.transform.position = spawnPoint;
//            //newCoins.transform.rotation = transform.rotation;
//            //newCoins.SetActive(true);
//        }
//    }
