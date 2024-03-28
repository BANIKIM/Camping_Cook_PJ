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
        if (_stickPos.Count < 1) return; //자리가 없으면 안 꽂아진다.
        //잘린건지 판단을 한다
        if (other.gameObject.GetComponent<Ingredient>().sliceCount > 0)
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            //잘렷으면 타입을 판단한다
            //리스트로 지우는것도 하고싶은데 고민이네 
            switch (ingred.ingredientType)
            {
                case IngredientType.Beef:
                    GameObject ob1= Instantiate(Foods[0], gameObject.transform);
                    ingred.skewerIngred.Change_Skewer_State(Skewer_State.Inserted); //상태인식
                    ob1.GetComponent<SeasoningIngredient>().pepper_s = ingred.GetComponent<SeasoningIngredient>().pepper_s;
                    ob1.GetComponent<SeasoningIngredient>().salt_s = ingred.GetComponent<SeasoningIngredient>().salt_s;
                    ob1.gameObject.transform.position = _stickPos[0].position;        // 꼬치에 끼움
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;
   /*             case Ingredient_Type.Mashmellow:
                    GameObject obj2 = Instantiate(Foods[1], gameObject.transform);
                    ingred._skewerIngred.Change_Skewer_State(Skewer_State.Inserted);
                    obj2.gameObject.transform.position = _stickPos[0].position;        // 꼬치에 끼움
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;*/
                case IngredientType.Potato:
                    GameObject obj3 = Instantiate(Foods[1], gameObject.transform);
                    obj3.gameObject.transform.position = _stickPos[0].position;        // 꼬치에 끼움
                    obj3.GetComponent<SeasoningIngredient>().pepper_s = ingred.GetComponent<SeasoningIngredient>().pepper_s;
                    obj3.GetComponent<SeasoningIngredient>().salt_s = ingred.GetComponent<SeasoningIngredient>().salt_s;
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;
                case IngredientType.Mushroom:
                    GameObject obj4 = Instantiate(Foods[2], gameObject.transform);
                    obj4.gameObject.transform.position = _stickPos[0].position;        // 꼬치에 끼움
                    obj4.GetComponent<SeasoningIngredient>().pepper_s = ingred.GetComponent<SeasoningIngredient>().pepper_s;
                    obj4.GetComponent<SeasoningIngredient>().salt_s = ingred.GetComponent<SeasoningIngredient>().salt_s;
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;
                case IngredientType.Onion:
                    GameObject obj5 = Instantiate(Foods[3], gameObject.transform);
                    obj5.gameObject.transform.position = _stickPos[0].position;        // 꼬치에 끼움
                    obj5.GetComponent<SeasoningIngredient>().pepper_s = ingred.GetComponent<SeasoningIngredient>().pepper_s;
                    obj5.GetComponent<SeasoningIngredient>().salt_s = ingred.GetComponent<SeasoningIngredient>().salt_s;
                    Destroy(other.gameObject);
                    _stickPos.RemoveAt(0);
                    break;
                default:
                    break;
            }
            //타입을 판단하고 리스트에 오브젝트를 활성화 시킨다
        }
        else if (!_stickPos.Count.Equals(0))
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            if (ingred.skewerIngred.skewer_state.Equals(Skewer_State.Idle))
            {
                XRGrabInteractable xrgrab = other.gameObject.GetComponent<XRGrabInteractable>();
                xrgrab = null;
                BoxCollider boxcoll = other.gameObject.GetComponent<BoxCollider>();
                if (boxcoll != null) boxcoll.isTrigger = true;
                ingred.skewerIngred.Change_Skewer_State(Skewer_State.Inserted);
                other.gameObject.transform.parent = gameObject.transform;     // 꼬치에 상속
                other.gameObject.transform.position = _stickPos[0].position;        // 꼬치에 끼움
                _stickPos.RemoveAt(0);
            }

        }
    }
}
