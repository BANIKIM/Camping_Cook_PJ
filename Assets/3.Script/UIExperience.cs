using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIExperience : MonoBehaviour
{

    public TextMeshProUGUI LevelUp2;

    public Slider slider2;
    public int StarCount = 0;


    public void UpdateValue()
    {

        slider2.value = GameManager.instance._needExp;

        // ���� ����ġ�� ���� ����ġ�� ���Ͽ� ������ �ؽ�Ʈ ������Ʈ
        if (GameManager.instance._needExp - GameManager.instance._currentExp <= slider2.minValue)
        {
            GameManager.instance._level++;


            LevelUp2.text = "ķ�� ���� : " + (GameManager.instance._level);
            GameManager.instance._needExp = 100;
        }
    }


}
