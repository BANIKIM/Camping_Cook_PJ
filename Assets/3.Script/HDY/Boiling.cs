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

    [Header("���� �ð� ����ϱ�")]
    public float water_HP = 0f;
    public float ingred_HP = 5f; //�� ����� hp
    public float All_hp = 0f; // ���� �ð�

    [Header("����� ��� ��Ƽ����")]
    public Material raw_carrot;
    public Material raw_beef;
    public Material raw_potato;
    public Material Stew_carrot;
    public Material Stew_beef;
    public Material Stew_potato;
    public Material burnt_food;

    private void Start()
    {
        //���� ���ۺ��� SetAcive(false)�� true�� �Ǿ null�� ��
        freshWater.GetComponent<MeshRenderer>().material = watherMat[0];

        Transform sliceCarrot = transform.Find("Slice_carrot");
        Transform sliceBeef = transform.Find("Slice_beef");
        Transform slicePotato = transform.Find("Slice_potato");

        //����� ó�� ��Ƽ����
        RawMat(sliceCarrot, sliceBeef, slicePotato);

        inputingred = FindObjectOfType<InputIngred>();
    }

    private void Update()
    {
        MyInput();

        if (pour_water)
        {
            panEnter.SetActive(true); //���� ���� �� ��ᰡ ��Ƶ� ��ᰡ ������� �ʱ� ����
        }
        else
        {
            panEnter.SetActive(false); //panEnter�� ó������ �������� ��ٿ����� ���� �ȶ�
        }

    }

    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //�� �ִ� ���� �ٲ� ��
        {
            freshWater.SetActive(true); //���� ���
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
            Debug.Log("�� ���̴� ��Ḧ ���� ����");
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
                Debug.Log("�� ����");
            }
            else if (All_hp <= -10)
            {
                Debug.Log("ź ����");
                freshWater.GetComponent<MeshRenderer>().material = watherMat[2];
                BurntMat(sliceCarrot, sliceBeef, slicePotato);

            }
            else
            {
                Debug.Log("Best Score");
                SmokeEff.SetActive(true); //����On
                freshWater.GetComponent<MeshRenderer>().material = watherMat[1];
                StewMat(sliceCarrot, sliceBeef, slicePotato);

            }
        }
    }

    IEnumerator LogOutAgain()
    {
        yield return new WaitForSeconds(1f); // 0.2f �ϴϱ� �ѹ��� 3�� 5�� ������
        logOut = true;
    }

    private void RawMat(Transform sliceCarrot, Transform sliceBeef, Transform slicePotato) //�ٸ� ��ᵵ �߰�
    {
        if (sliceCarrot != null)
        {
            // Slice_carrot�� ��� �ڽ��� ������
            int childCount = sliceCarrot.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = sliceCarrot.GetChild(i);
                Renderer childRenderer = child.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    Material[] materials = childRenderer.materials;
                    materials[0] = raw_carrot; // ���ϴ� ��Ƽ����
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
            // Slice_carrot�� ��� �ڽ��� ������
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
            // Slice_carrot�� ��� �ڽ��� ������
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
