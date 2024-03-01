using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIExperience : MonoBehaviour
{

    public TextMeshProUGUI _levelText;

    public Slider _expSlider;
    public int StarCount = 0;


    public void UpdateValue()
    {

        _expSlider.value = GameManager.instance._needExp;

        // ���� ����ġ�� ���� ����ġ�� ���Ͽ� ������ �ؽ�Ʈ ������Ʈ
        if (GameManager.instance._needExp - GameManager.instance._currentExp <= _expSlider.minValue)
        {
            GameManager.instance._level++;


            _levelText.text = "ķ�� ���� : " + (GameManager.instance._level);
            GameManager.instance._needExp = 100;
        }
    }


}
