using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private GameObject[] LockObj;
    private void update()
    {
        LockOff();
    }
    public void LockOff()
    {
        if (GameManager.instance._level >= 0)
        {
            LockObj[2].SetActive(false);
        }
        else if (GameManager.instance._level >= 0)
        {
            LockObj[1].SetActive(false);
        }
        else if (GameManager.instance._level >= 0)
        {
            LockObj[0].SetActive(false);
        }
    }
}
