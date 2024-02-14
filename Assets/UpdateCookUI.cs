using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CookingStatus
{
    Default,
    Update

}
public class UpdateCookUI : MonoBehaviour
{
    [SerializeField]
    private CookingStatus cookingStatus; 

    [SerializeField]
    private GameObject updateObject;

    public void OpenUpdate()
    {
        // �丮 ���°� ������Ʈ���� Ȯ��
        if (cookingStatus == CookingStatus.Update)
        {
            // ���� ������Ʈ�� Ȱ��ȭ
            updateObject.SetActive(true);
        }
    }
    public void OffUpdate()
    {
        if (cookingStatus == CookingStatus.Default)
        {
            updateObject.SetActive(false);
        }
    }
}
