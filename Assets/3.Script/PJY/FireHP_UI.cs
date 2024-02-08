using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHP_UI : MonoBehaviour
{
    public Gradient gradient;
    public Slider slider;
    public Image image;

    [SerializeField] private CampFire campFire;



    void Update()
    {
        // 캠프파이어의 HP 값을 슬라이더의 값으로 업데이트합니다.
        if (campFire != null && slider != null)
        {
            slider.value = campFire.HP;
            image.color = gradient.Evaluate(campFire.HP / (float)campFire.maxHP);
        }
    }
}
