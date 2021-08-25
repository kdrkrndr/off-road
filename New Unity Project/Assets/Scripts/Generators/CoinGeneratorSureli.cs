using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneratorSureli : MonoBehaviour
{
    public ObjectPooler[] coins;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public float startWait;
    public bool stop;
    public Vector3 startPosition;
    public Transform generatePoint;

    int randomCoins;

    private void Start()
    {
        //StartCoroutine(waitSpawner());
    }

    private void Update()
    {
        //spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        if (transform.position.x < generatePoint.position.x)
        {
            randomCoins = Random.Range(0, coins.Length);
            //x ekseninde rastgele bi konumda oluşmasını sağlıyor.
            Vector3 spawnPosition = new Vector3(Random.Range(-generatePoint.position.x, 1 + generatePoint.position.x), generatePoint.position.y, generatePoint.position.z);

            GameObject newcoin = coins[randomCoins].GetPooledObject();
            newcoin.transform.position = spawnPosition;
            newcoin.SetActive(true);

        }

    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);


        //if (transform.position.x < generatePoint.position.x)

        yield return new WaitForSeconds(spawnWait);
    }



    //public Transform generatePoint;
    //public Vector3 spawnValue;
    //public bool stop;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (transform.position.x < generatePoint.position.x)
    //    {
    //        //while (!stop)
    //        //{
    //            //transform.position = new Vector3(transform.position.x/* +groundWidth*/, transform.position.y, transform.position.z);

    //            transform.position = new Vector3(transform.position.x+Random.Range(-spawnValue.x, spawnValue.x), transform.position.y, 0);


    //            GameObject coin1 = newObjectPooler.SharedInstance.GetPooledObject("GoldPool");
    //            if (coin1 != null)
    //            {
    //                coin1.transform.position = transform.position;
    //                coin1.transform.rotation = transform.rotation;
    //                coin1.SetActive(true);
    //            }
    //            GameObject coin2 = newObjectPooler.SharedInstance.GetPooledObject("SilverPool");
    //            if (coin2 != null)
    //            {
    //                coin2.transform.position = transform.position;
    //                coin2.transform.rotation = transform.rotation;
    //                coin2.SetActive(true);
    //            }
    //            GameObject coin3 = newObjectPooler.SharedInstance.GetPooledObject("SilverPool");
    //            if (coin3 != null)
    //            {
    //                coin3.transform.position = transform.position;
    //                coin3.transform.rotation = transform.rotation;
    //                coin3.SetActive(true);
    //            }
    //        //}            
    //    }
    //}


}
