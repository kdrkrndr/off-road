using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GroundGenerator : MonoBehaviour
{
    public ObjectPooler[] theGroundPools;
    public GameObject ground;
    public Transform generatePoint;
    public int firstGroundNumb;
    int currentGroundNumber;

    private float groundWidth=35.99f;

    //public GameObject[] grounds;
    private int groundNumber;
    private SilverCoinGenerator theCoinGenerator;


    public CoinPooler[] theCoinPools;
    private int coinNumber;
    private int coinNumber1;
    private int coinNumber2;
    private int coinNumber3;
    private float number;

    private void Start()
    {
        //FirstGroundGenerate();
        Instantiate(ground,transform.position, transform.rotation);
        theCoinGenerator = FindObjectOfType<SilverCoinGenerator>();
    }

    private void FixedUpdate()
    {
        GroundGenerate();        
    }

    //public void FirstGroundGenerate()
    //{
    //    Debug.Log("Ground Amount " + thegroundPools.Length);
    //    int groundNumber1;
    //        groundNumber1 = Random.Range(0, thegroundPools.Length);//havuzdan rastgele obje çekiyor.
    //        GameObject newPlatform = thegroundPools[groundNumber1].GetPooledObject();
    //        newPlatform.transform.position = transform.position;
    //        newPlatform.transform.rotation = transform.rotation;
    //        newPlatform.SetActive(true);
    //        firstGroundNumb = groundNumber1;
    //        currentGroundNumber = firstGroundNumb;
    //    Debug.Log("First Ground Number " + currentGroundNumber);
    //}

    /*public void WhichGround() //zeminlerin hangi sırayla yerleştirileceğeini belirler ay
    {
        switch (currentGroundNumber)
        {
            case 0:
                groundNumber = Random.Range(0, 3);
                currentGroundNumber = groundNumber;
                break;
            case 1:
                groundNumber = Random.Range(4, 7);
                currentGroundNumber = groundNumber;
                break;
            case 2:
                groundNumber = Random.Range(8, 11);
                currentGroundNumber = groundNumber;
                break;
            case 3:
                groundNumber = Random.Range(12, 15);
                currentGroundNumber = groundNumber;
                break;
            case 4:
                groundNumber = Random.Range(0, 3);
                currentGroundNumber = groundNumber;
                break;
            case 5:
                groundNumber = Random.Range(4, 7);
                currentGroundNumber = groundNumber;
                break;
            case 6:
                groundNumber = Random.Range(8, 11);
                currentGroundNumber = groundNumber;
                break;
            case 7:
                groundNumber = Random.Range(12, 15);
                currentGroundNumber = groundNumber;
                break;
            case 8:
                groundNumber = Random.Range(0, 3);
                currentGroundNumber = groundNumber;
                break;
            case 9:
                groundNumber = Random.Range(4, 7);
                currentGroundNumber = groundNumber;
                break;
            case 10:
                groundNumber = Random.Range(8, 11);
                currentGroundNumber = groundNumber;
                break;
            case 11:
                groundNumber = Random.Range(12, 15);
                currentGroundNumber = groundNumber;
                break;
            case 12:
                groundNumber = Random.Range(0, 3);
                currentGroundNumber = groundNumber;
                break;
            case 13:
                groundNumber = Random.Range(4, 7);
                currentGroundNumber = groundNumber;
                break;
            case 14:
                groundNumber = Random.Range(8, 11);
                currentGroundNumber = groundNumber;
                break;
            case 15:
                groundNumber = Random.Range(12, 15);
                currentGroundNumber = groundNumber;
                break;
            default:
                break;
        }
    }*/

    public void GroundGenerate()//zeminlerin yerleştirilieceği konumları belirler
    {
        

        if (transform.position.x < generatePoint.position.x)
        {
            //WhichGround();
            groundNumber = Random.Range(0, 5);
            transform.position = new Vector3(transform.position.x + groundWidth, transform.position.y, transform.position.z);
            GameObject newPlatform = theGroundPools[groundNumber].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            CoinGenerate();
        }
        
    }

    public void Yerlestirici()//coinlerin yerleştirilieceği konumları belirler
    {
        number = Random.Range(generatePoint.position.x, generatePoint.position.x + 26);
        Vector3 position = new Vector3(number, transform.position.y, transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.up, 30f);
        if (hit.collider!=null && hit.collider.gameObject.tag == "ground")//ground taglı nesneye çarptığı zaman işlem olmasını istiyoruz
        {
            Vector3 spawn_point = new Vector3(position.x, hit.point.y + 1f, position.z);
            GameObject newCoin = theCoinPools[coinNumber].GetPooledObject1();
            newCoin.transform.position = spawn_point;
            newCoin.SetActive(true);
        }
        else
        {

        }
    }

    public void CoinGenerate()
    {
        int durum = Random.Range(1, 4);
        switch (durum)
        {
            case 1:

                coinNumber = Random.Range(1, 14);
                Yerlestirici();

                break;
            case 2:
                coinNumber = Random.Range(1, 14);
                Yerlestirici();

                coinNumber1 = Random.Range(1, 14);
                Yerlestirici();

                break;
            case 3:
                coinNumber = Random.Range(1, 14);
                Yerlestirici();

                coinNumber1 = Random.Range(1, 14);
                Yerlestirici();

                coinNumber2 = Random.Range(1, 14);
                Yerlestirici();

                break;
            case 4:
                coinNumber = Random.Range(1, 14);
                Yerlestirici();

                coinNumber1 = Random.Range(1, 14);
                Yerlestirici();

                coinNumber2 = Random.Range(1, 14);
                Yerlestirici();

                coinNumber3 = Random.Range(1, 14);
                Yerlestirici();

                break;
            default:
                break;
        }

    }
}
