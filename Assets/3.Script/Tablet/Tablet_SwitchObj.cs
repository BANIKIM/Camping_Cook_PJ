using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tablet_SwitchObj : MonoBehaviour
{
    [SerializeField] private GameObject _home1Obj;
    [SerializeField] private GameObject _home2Obj;
    [SerializeField] private Image _panel;
    [SerializeField] private Sprite[] _panels;

    private bool isHome1 = true;

    public void Btn_SwitchObj()
    {
        if(isHome1)
        {
            isHome1 = false;
            _home1Obj.SetActive(false);
            _home2Obj.SetActive(true);
            _panel.sprite = _panels[1];
        }
        else
        {
            isHome1 = true;
            _home1Obj.SetActive(true);
            _home2Obj.SetActive(false);
            _panel.sprite = _panels[0];
        }
    }
}
