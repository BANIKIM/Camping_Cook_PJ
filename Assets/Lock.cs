using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private GameObject[] LockObj;
    private void OnEnable()
    {
        LockOff();
    }
    public void LockOff()
    {
        if (UiManager.instance.ExpUI.level >= 20)
        {
            LockObj[2].SetActive(false);
        }
        else if (UiManager.instance.ExpUI.level >= 15)
        {
            LockObj[1].SetActive(false);
        }
        else if (UiManager.instance.ExpUI.level >= 10)
        {
            LockObj[0].SetActive(false);
        }
    }
}
