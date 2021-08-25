//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CheckPoint : MonoBehaviour
//{
//    // Indicate if the checkpoint is activated
//    public bool activated = false;
//    private GameObject checkpoint;

//    private Animator thisAnimator;

//    // List with all checkpoint objects in the scene
//    public static GameObject[] checkPoints;


//    void Start()
//    {
//        // We search all the checkpoints in the current scene
//        checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
//        //thisAnimator = GetComponent<Animator>();

//    }
    
//    // Activate the checkpoint
//    private void ActivateCheckPoint()
//    {
//        // We deactive all checkpoints in the scene
//        foreach (GameObject cp in checkPoints)
//        {
//            cp.GetComponent<CheckPoint>().activated = false;
//            /* cp.GetComponent<Animator>().SetBool("Active", false)*/
//            ;//animator eklenince çalışacak
//        }
//        // We activate the current checkpoint
//        activated = true;
//        //thisAnimator.SetBool("Active", true);
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        // If the player passes through the checkpoint, we activate it
//        if (other.tag == "Player")
//        {
//            ActivateCheckPoint();
//        }
//    }
  
//    // Get position of the last activated checkpoint
//    public static Vector3 GetActiveCheckPointPosition()
//    {
//        // If player die without activate any checkpoint, we will return a default position
//        Vector3 result = new Vector3(0, 0, 0);

//        if (checkPoints != null)
//        {
//            foreach (GameObject cp in checkPoints)
//            {
//                // We search the activated checkpoint to get its position
//                if (cp.GetComponent<CheckPoint>().activated)
//                {
//                    result = cp.transform.position;
//                    break;
//                }
//            }
//        }

//        return result;
//    }
//}

