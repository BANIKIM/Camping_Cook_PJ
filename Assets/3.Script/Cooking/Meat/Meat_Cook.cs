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
    //�޼��� ȣ���ؼ� Ȯ�ι޾Ƶ� �ǰ� Update������ ��� �ֽ�ȭ�� ���൵ �� �޼��� ȣ���ϴ°� �� ����Ҳ������� �÷����� �� �� �ѹ��� �޾Ƶ� �Ǵϱ�.
    public void Roasting_complete()
    {
        if (meat_up_State.cooked_state == Cooked_Ingredient.Cooked_State.Roasted &&
           meat_down_State.cooked_state == Cooked_Ingredient.Cooked_State.Roasted)
        {
            meat_steak.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Roasted);//����Ŵ�
        }
        else
        {
            meat_steak.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burnt); // �ƴϸ� �� ź�Ŵ�.
        }
    }
}
