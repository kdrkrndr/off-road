using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public bool isUnLock = false;
    public GameObject lockGo;
    public GameObject unLockGo;

    public int questNum;// how many stars can unlock this map
    public int startLevel;
    public int endLevel;

    private void Update()
    {
        UpdateMapStatus();//todo remove later because we don't want to call this metad each frame
        UnlockMap();
    }

    private void UpdateMapStatus()
    {
        if (isUnLock)//we can play this map.
        {
            unLockGo.gameObject.SetActive(true);
            lockGo.gameObject.SetActive(false);
        }
        else//this map still lock. we have to complete his quest.
        {
            unLockGo.gameObject.SetActive(false);
            lockGo.gameObject.SetActive(true);
        }
    }

    private void UnlockMap()
    {

        if (UIManager.instance.stars>=questNum)
        {
            isUnLock = true;
        }
        else
        {
            isUnLock = false;
        }
    }
}
