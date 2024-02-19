using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpUI : MonoBehaviour
{
    [SerializeField] private CampFire campFire;
    public TextMeshProUGUI LevelUp;
    public TextMeshProUGUI LevelUp2;
    public Slider slider;
    public Slider slider2;
    public  int level=1;

    private void Update()
    {
        if (campFire != null && slider != null)
        {
            slider.value = campFire.Exp;
            slider2.value = campFire.Exp;

            // ���� ����ġ�� ���� ����ġ�� ���Ͽ� ������ �ؽ�Ʈ ������Ʈ
            if (campFire.Exp <= slider.minValue)
            {
                level++;
                LevelUp.text = "ķ�� ���� : " + (level);
               
                LevelUp2.text= "ķ�� ���� : " + (level);
                campFire.Exp = 100;
               
            }

        }
    }
}
