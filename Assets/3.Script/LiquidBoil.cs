using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LiquidBoil : MonoBehaviour
{
    public GameObject Cook_Tool_pot;
    public Tool_heat heat;
    public GameObject smoke;
    public float HP = 10;
    public GameObject[] Foods;
    private CookedIngredient cooked;
    private Ingredient ingredient;
    private int number = 0;
    private bool a;
    public Slider Time_slider;

    [SerializeField] private AudioSource _audiosource;


    public bool iscook = false;
    private bool isBurned = false;
    public bool isDish = false;

    void Start()
    {
        heat = Cook_Tool_pot.gameObject.GetComponent<Tool_heat>();
        cooked = GetComponent<CookedIngredient>();
        ingredient = GetComponent<Ingredient>();
    }

    private void FixedUpdate()
    {
        if (heat.isToolHeat)
        {
            HP -= Time.deltaTime;
            Time_slider.value = HP;
            Onsmoke();//����ũ ����Ʈ Ű��
            isTan();//�ð������� Ž


        }

        for (int i = 0; i < Foods.Length; i++)
        {
            if(Foods[i].activeSelf == true)
            {
                isDish = false;
                break;
            }
            else
            {
                isDish = true;

            }

        }
        if(isDish && iscook)
        {
            Debug.Log("�����׸��� �ʱ�ȭ");
            LiquidReset();//�� ���׸��� �ʱ�ȭ
            _audiosource.Stop();

        }
        else if(isDish) _audiosource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            if (!_audiosource.isPlaying)
            {
                _audiosource.Play();
            }

            HP = 10;//�ٷ� Ÿ�°� ����
            HP += 5;
            Time_slider.maxValue = HP;
            Time_slider.value = HP;
            Destroy(other.gameObject);

            for (int i = 0; i < Foods.Length; i++)
            {
                a = false;
                if (Foods[i].GetComponent<Ingredient>().ingredientType == other.GetComponent<Ingredient>().ingredientType)
                {
                    a = true;
                    break;
                }
            }
            if (!a)
            {
                Foods[number].GetComponent<Ingredient>().ingredientType = other.GetComponent<Ingredient>().ingredientType;
                Foods[number].GetComponent<Ingredient>().sliceCount = other.GetComponent<Ingredient>().sliceCount;
                Foods[number].GetComponent<SeasoningIngredient>().salt_s = other.GetComponent<SeasoningIngredient>().salt_s;
                Foods[number].GetComponent<SeasoningIngredient>().pepper_s = other.GetComponent<SeasoningIngredient>().pepper_s;
                Foods[number].SetActive(true);
                number += 1;
            }
            if (number == 4) number = 0;


        }
    }
    private void Onsmoke()
    {
        if (HP < 5 && !iscook)
        {
            if (!isDish)
            {
                for (int i = 0; i < Foods.Length; i++)
                {
                    Foods[i].GetComponent<CookedIngredient>().Change_Cooked_State(CookedIngredient.Cooked_State.Cook);
                }
                cooked.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);//�������ͽ� ����
                ingredient.Cook_ch_mat();//���׸��� ����
                ingredient.crossMat = ingredient.mesh.material;
                iscook = true;
            }
            
        }

    }

    private void isTan()
    {
        if (HP < 0 && !isDish && !isBurned)
        {
            for (int i = 0; i < Foods.Length; i++)
            {
                Foods[i].GetComponent<CookedIngredient>().Change_Cooked_State(CookedIngredient.Cooked_State.Burned);
            }
            cooked.Change_Cooked_State(CookedIngredient.Cooked_State.Burned);//�������ͽ� ����
            ingredient.Cook_ch_mat();//���׸��� ����
            ingredient.crossMat = ingredient.mesh.material;

            isBurned = true;
        }
    }

    public void LiquidReset()//���� ���׸��� �� �ʱ�� ������.
    {
        cooked.Change_Cooked_State(CookedIngredient.Cooked_State.Raw);//�������ͽ� ����
        ingredient.Cook_ch_mat();//���׸��� ����
        ingredient.crossMat = ingredient.mesh.material;
        iscook = false;
        isBurned = false;
    }

    public void CookReset()//���ʱ�ȭ
    {
        for (int i = 0; i < Foods.Length; i++)
        {
            if(Foods[i].activeSelf==true)
            {
                Foods[i].GetComponent<Ingredient>().ingredientType = 0; //Ÿ��0���θ����
                Foods[i].GetComponent<Ingredient>().sliceCount = 0; //�����̽� 0���� �����
                Foods[i].GetComponent<CookedIngredient>().Change_Cooked_State(CookedIngredient.Cooked_State.Raw);//�����ʱ�ȭ
                Foods[i].GetComponent<SeasoningIngredient>().salt_s = 0; //�ұ��ʱ�ȭ
                Foods[i].GetComponent<SeasoningIngredient>().pepper_s = 0;//�����ʱ�ȭ
                Foods[i].gameObject.SetActive(false);
            }
        }
    }
}
