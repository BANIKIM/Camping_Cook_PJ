using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Skewer : MonoBehaviour
{
    [SerializeField] private List<Transform> _stickPos;
    [SerializeField] private LayerMask _cookLayer;
    public GameObject[] Foods;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer != 6)return;
        if (_stickPos.Count < 1) return; //�ڸ��� ������ �� �Ⱦ�����.
        //�߸����� �Ǵ��� �Ѵ�
        if (other.gameObject.GetComponent<Ingredient>()._sliceCount > 0)
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            //�߷����� Ÿ���� �Ǵ��Ѵ�
            //����Ʈ�� ����°͵� �ϰ������ ����̳� 
            switch (ingred._ingredient_Type)
            {
                case Ingredient_Type.Beef:
                    GameObject ob1= Instantiate(Foods[0], gameObject.transform);
                    ingred._skewerIngred.Change_Skewer_State(Skewer_State.Inserted); //�����ν�
                    ob1.GetComponent<Seasoning_Ingredient>().pepper_s = ingred.GetComponent<Seasoning_Ingredient>().pepper_s;
                    ob1.GetComponent<Seasoning_Ingredient>().salt_s = ingred.GetComponent<Seasoning_Ingredient>().salt_s;
                    ob1.gameObject.transform.position = _stickPos[0].position;        // ��ġ�� ����
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;
   /*             case Ingredient_Type.Mashmellow:
                    GameObject obj2 = Instantiate(Foods[1], gameObject.transform);
                    ingred._skewerIngred.Change_Skewer_State(Skewer_State.Inserted);
                    obj2.gameObject.transform.position = _stickPos[0].position;        // ��ġ�� ����
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;*/
                case Ingredient_Type.Potato:
                    ingred._skewerIngred.Change_Skewer_State(Skewer_State.Inserted);//�����ν�
                    GameObject obj3 = Instantiate(Foods[1], gameObject.transform);
                    obj3.gameObject.transform.position = _stickPos[0].position;        // ��ġ�� ����
                    obj3.GetComponent<Seasoning_Ingredient>().pepper_s = ingred.GetComponent<Seasoning_Ingredient>().pepper_s;
                    obj3.GetComponent<Seasoning_Ingredient>().salt_s = ingred.GetComponent<Seasoning_Ingredient>().salt_s;
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;
                case Ingredient_Type.Mushroom:
                    ingred._skewerIngred.Change_Skewer_State(Skewer_State.Inserted);//�����ν�
                    GameObject obj4 = Instantiate(Foods[2], gameObject.transform);
                    obj4.gameObject.transform.position = _stickPos[0].position;        // ��ġ�� ����
                    obj4.GetComponent<Seasoning_Ingredient>().pepper_s = ingred.GetComponent<Seasoning_Ingredient>().pepper_s;
                    obj4.GetComponent<Seasoning_Ingredient>().salt_s = ingred.GetComponent<Seasoning_Ingredient>().salt_s;
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;
                default:
                    break;
            }
            //Ÿ���� �Ǵ��ϰ� ����Ʈ�� ������Ʈ�� Ȱ��ȭ ��Ų��
        }
        else if (!_stickPos.Count.Equals(0))
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            if (ingred._skewerIngred.skewer_state.Equals(Skewer_State.Idle))
            {
                XRGrabInteractable xrgrab = other.gameObject.GetComponent<XRGrabInteractable>();
                xrgrab = null;

                ingred._skewerIngred.Change_Skewer_State(Skewer_State.Inserted);
                other.gameObject.transform.parent = gameObject.transform;     // ��ġ�� ���
                other.gameObject.transform.position = _stickPos[0].position;        // ��ġ�� ����
                _stickPos.RemoveAt(0);
            }

        }
    }
}
