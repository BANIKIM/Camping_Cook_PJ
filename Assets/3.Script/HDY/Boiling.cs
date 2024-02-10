using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiling : MonoBehaviour
{
    [SerializeField] GameObject freshWater;
    [SerializeField] GameObject SlicedCarrot;
    [SerializeField] GameObject SlicedBeef;
    [SerializeField] GameObject SlicedPotato;

    [SerializeField] GameObject SmokeEff;

    public Material[] watherMat = new Material[3];

    [SerializeField] private InputIngred inputingred;
    [SerializeField] GameObject panEnter;

    private bool pour_water = false;
    private bool logOut = true;

    [Header("끓는 시간 계산하기")]
    public float water_HP = 0f;
    public float ingred_HP = 5f; //각 재료의 hp
    public float All_hp = 0f; // 끓는 시간

    [Header("재료의 모든 머티리얼")]
    public Material raw_carrot;
    public Material raw_beef;
    public Material raw_potato;
    public Material Stew_carrot;
    public Material Stew_beef;
    public Material Stew_potato;
    public Material burnt_food;

    private void Start()
    {
        //물은 시작부터 SetAcive(false)라서 true가 되어도 null이 뜸
        freshWater.GetComponent<MeshRenderer>().material = watherMat[0];

        Transform sliceCarrot = transform.Find("Slice_carrot");
        Transform sliceBeef = transform.Find("Slice_beef");
        Transform slicePotato = transform.Find("Slice_potato");

        //재료의 처음 머티리얼
        RawMat(sliceCarrot, sliceBeef, slicePotato);

        inputingred = FindObjectOfType<InputIngred>();
    }

    private void Update()
    {
        MyInput();

        if (pour_water)
        {
            panEnter.SetActive(true); //물이 없을 때 재료가 닿아도 재료가 사라지지 않기 위함
        }
        else
        {
            panEnter.SetActive(false); //panEnter을 처음부터 꺼버리면 당근옵젝이 물에 안뜸
        }

    }

    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //물 넣는 조건 바꿀 것
        {
            freshWater.SetActive(true); //물이 담김
            pour_water = true;
        }

        if (pour_water)
        {
            if (inputingred.inputCarrot && logOut)
            {
                SlicedCarrot.SetActive(true);
                All_hp += ingred_HP;
                Debug.Log("All_hp : " + All_hp);
                logOut = false;
                StartCoroutine(LogOutAgain());
            }

            if (inputingred.inputBeef && logOut)
            {
                SlicedBeef.SetActive(true);
                All_hp += ingred_HP;
                Debug.Log("All_hp : " + All_hp);
                logOut = false;
                StartCoroutine(LogOutAgain());
            }

            if (inputingred.inputPotato && logOut)
            {
                SlicedPotato.SetActive(true);
                All_hp += ingred_HP;
                Debug.Log("All_hp : " + All_hp);
                logOut = false;
                StartCoroutine(LogOutAgain());
            }

        }
        else
        {
            Debug.Log("물 없이는 재료를 넣지 못함");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        Transform sliceCarrot = transform.Find("Slice_carrot");
        Transform sliceBeef = transform.Find("Slice_beef");
        Transform slicePotato = transform.Find("Slice_potato");

        if (other.gameObject.CompareTag("GrillGrate"))
        {
            All_hp -= Time.deltaTime;

            if (All_hp > 0)
            {
                Debug.Log("덜 익음");
            }
            else if (All_hp <= -10)
            {
                Debug.Log("탄 상태");
                freshWater.GetComponent<MeshRenderer>().material = watherMat[2];
                BurntMat(sliceCarrot, sliceBeef, slicePotato);

            }
            else
            {
                Debug.Log("Best Score");
                SmokeEff.SetActive(true); //연기On
                freshWater.GetComponent<MeshRenderer>().material = watherMat[1];
                StewMat(sliceCarrot, sliceBeef, slicePotato);

            }
        }
    }

    IEnumerator LogOutAgain()
    {
        yield return new WaitForSeconds(1f); // 0.2f 하니까 한번에 3번 5씩 더해짐
        logOut = true;
    }

    private void RawMat(Transform sliceCarrot, Transform sliceBeef, Transform slicePotato) //다른 재료도 추가
    {
        if (sliceCarrot != null)
        {
            // Slice_carrot의 모든 자식을 가져옴
            int childCount = sliceCarrot.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = sliceCarrot.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = raw_carrot; // 원하는 머티리얼
                    childRenderer.materials = materials;
                }
            }
        }

        if (sliceBeef != null)
        {
            int childCount = sliceBeef.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = sliceBeef.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = raw_beef;
                    childRenderer.materials = materials;
                }
            }
        }

        if (slicePotato != null)
        {
            int childCount = slicePotato.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = slicePotato.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = raw_potato;
                    childRenderer.materials = materials;
                }
            }
        }
    }
    private void StewMat(Transform sliceCarrot, Transform sliceBeef, Transform slicePotato)
    {
        if (sliceCarrot != null)
        {
            // Slice_carrot의 모든 자식을 가져옴
            int childCount = sliceCarrot.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = sliceCarrot.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = Stew_carrot;
                    childRenderer.materials = materials;
                }
            }
        }

        if (sliceBeef != null)
        {
            int childCount = sliceBeef.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = sliceBeef.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = Stew_beef;
                    childRenderer.materials = materials;
                }
            }
        }

        if (slicePotato != null)
        {
            int childCount = slicePotato.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = slicePotato.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = Stew_potato;
                    childRenderer.materials = materials;
                }
            }
        }
    }

    private void BurntMat(Transform sliceCarrot, Transform sliceBeef, Transform slicePotato)
    {
        if (sliceCarrot != null)
        {
            // Slice_carrot의 모든 자식을 가져옴
            int childCount = sliceCarrot.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = sliceCarrot.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = burnt_food;
                    childRenderer.materials = materials;
                }
            }
        }

        if (sliceBeef != null)
        {
            int childCount = sliceBeef.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = sliceBeef.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = burnt_food;
                    childRenderer.materials = materials;
                }
            }
        }

        if (slicePotato != null)
        {
            int childCount = slicePotato.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = slicePotato.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = burnt_food;
                    childRenderer.materials = materials;
                }
            }
        }
    }
}
