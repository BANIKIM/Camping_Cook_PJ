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
        // ķ�����̾��� HP ���� �����̴��� ������ ������Ʈ�մϴ�.
        if (campFire != null && slider != null)
        {
            slider.value = campFire.HP;
            image.color = gradient.Evaluate(campFire.HP / (float)campFire.maxHP);
        }
    }
}
