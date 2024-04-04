using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public List<int> _prep_List = new List<int>();
    public List<int> _cook_List = new List<int>();
    public GameObject[] Cooks;
    public bool onech = false;

    [SerializeField]
    private GameObject uI_DB_ParsingObj;

    [SerializeField]
    private UI_DB_Parsing uI_DB_Parsing;

    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        uI_DB_ParsingObj = GameObject.FindGameObjectWithTag("UIManager");
        uI_DB_Parsing = uI_DB_ParsingObj.GetComponent<UI_DB_Parsing>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();

            if (!_prep_List.Contains(ingred.CheckPrepIdx())) _prep_List.Add(ingred.CheckPrepIdx());
            if (!_cook_List.Contains(ingred.CheckCookIdx())) _cook_List.Add(ingred.CheckCookIdx());



            Cooks[GameManager.instance._cookIdx].SetActive(true);
            //Destroy(other.gameObject);
            //�����ʱ�ȭ ����� �Ѵ�...
            ingred._ingredient_Type = 0; //Ÿ��0���θ����
            ingred._sliceCount = 0; //�����̽� 0���� �����
            other.GetComponent<Cooked_Ingredient>().Change_Cooked_State(Cooked_Ingredient.Cooked_State.Raw);//�����ʱ�ȭ
            other.GetComponent<Seasoning_Ingredient>().salt_s = 0; //�ұ��ʱ�ȭ
            other.GetComponent<Seasoning_Ingredient>().pepper_s = 0;//�����ʱ�ȭ
            other.gameObject.SetActive(false);

        }

        /* if (other.gameObject.CompareTag("Liquid"))
         {
             other.GetComponent<LiquidBoil>().LiquidReset();
             other.gameObject.SetActive(false);
         }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Ingredient ingred = collision.gameObject.GetComponent<Ingredient>();

            if (!_prep_List.Contains(ingred.CheckPrepIdx())) _prep_List.Add(ingred.CheckPrepIdx());
            if (!_cook_List.Contains(ingred.CheckCookIdx())) _cook_List.Add(ingred.CheckCookIdx());



            Cooks[GameManager.instance._cookIdx].SetActive(true);
            Destroy(collision.gameObject);

        }
    }

    public int ch_Reward()//������ üũ
    {
        Cooks[GameManager.instance._cookIdx].SetActive(false);
        if (!onech)
        {
            ok(GameManager.instance._cookIdx.ToString());
            _audioSource.PlayOneShot(_audioSource.clip);
            onech = true;
        }
        return RewardManager.instance.RecipeCheck(_prep_List, _cook_List, GameManager.instance._cookIdx);
    }


    public void ok(string i)//������ ��ȯ
    {
        uI_DB_Parsing.textType = UI_DB_Parsing.TextType.Cook;
        uI_DB_Parsing.number = i;
        uI_DB_Parsing.a = true;
    }


}