using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat_Cook : MonoBehaviour
{

    public GameObject Meat_Up;
    public GameObject Meat_Down;
    private Cooked_Ingredient meat_steak;
    private Cooked_Ingredient meat_up_State;
    private Cooked_Ingredient meat_down_State;

    void Start()
    {
        meat_up_State = Meat_Up.GetComponent<Cooked_Ingredient>();
        meat_down_State = Meat_Down.GetComponent<Cooked_Ingredient>();
        meat_steak = GetComponent<Cooked_Ingredient>();
    }

    private void Update()
    {
        Roasting_complete();
    }
    //메서드 호출해서 확인받아도 되고 Update문에서 계속 최신화를 해줘도 됨 메서드 호출하는게 더 깔끔할꺼같긴함 플레이팅 할 때 한번만 받아도 되니깐.
    public void Roasting_complete()
    {
        if (meat_up_State.cooked_state == Cooked_Ingredient.Cooked_State.Roasted &&
           meat_down_State.cooked_state == Cooked_Ingredient.Cooked_State.Roasted)
        {
            meat_steak.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Roasted);//구운거다
        }
        else
        {
            meat_steak.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burnt); // 아니면 다 탄거다.
        }
    }
}
