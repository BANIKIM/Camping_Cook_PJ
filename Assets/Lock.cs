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
        if (UiManager.instance._uiExperience.level >= 20)
        {
            LockObj[2].SetActive(false);
        }
        else if (UiManager.instance._uiExperience.level >= 15)
        {
            LockObj[1].SetActive(false);
        }
        else if (UiManager.instance._uiExperience.level >= 10)
        {
            LockObj[0].SetActive(false);
        }
    }
}
