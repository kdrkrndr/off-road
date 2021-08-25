//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BronzeCoinGenerator : MonoBehaviour
//{
//    public Transform generatePoint;
//    public float minPoint;
//    public float maxPoint;

//    private void Start()
//    {

//    }

//    private void FixedUpdate()
//    {
//        if (transform.position.x < generatePoint.position.x)
//        {
//            Vector3 position = new Vector3(transform.position.x + Random.Range(minPoint, maxPoint), transform.position.y, transform.position.z);
//            // Cast a ray straight down.
//            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down);
//            // If it hits something...
//            if (hit.collider != null)
//            {
//                Vector3 spawn_point = new Vector3(position.x, hit.point.y + 1f, transform.position.z);
//                GameObject coin = CoinPooler.SharedInstance.GetPooledObject("Bronze");
//                if (coin != null)
//                {
//                    coin.transform.position = spawn_point;
//                    coin.SetActive(true);
//                }
//            }

//        }
//    }
//}

