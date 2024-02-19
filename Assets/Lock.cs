using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private GameObject LockObj;
    public void LockOff()
    {
        if (UiManager.instance.ExpUI.level>=10)
        {
            gameObject.SetActive(false);
        }
    }
}
