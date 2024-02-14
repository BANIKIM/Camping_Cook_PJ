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
        // 요리 상태가 업데이트인지 확인
        if (cookingStatus == CookingStatus.Update)
        {
            // 게임 오브젝트를 활성화
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
