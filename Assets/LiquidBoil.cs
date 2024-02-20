using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBoil : MonoBehaviour
{
    public GameObject Cook_Tool_pot;
    public Tool_heat heat;
    public GameObject smoke;
    public float HP = 10;
    void Start()
    {
        heat = Cook_Tool_pot.gameObject.GetComponent<Tool_heat>();
    }

    private void FixedUpdate()
    {
        if (heat.tool_heat)
        {
            HP -= Time.deltaTime;
            Onsmoke();//스모크 이펙트 키기
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Boil boil = other.GetComponent<Boil>();
            HP += boil.HP;
        }
    }

    private void Onsmoke()
    {
        if (HP < 5)
        {
            smoke.SetActive(true);
        }
        else
        {
            smoke.SetActive(false);
        }
    }
}
