using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignigt : MonoBehaviour
{
    public GameObject fire;

    // 버튼을 누를 때 호출할 메서드
    public void ToggleFire()
    {
        // fire 게임 오브젝트의 활성화 상태를 토글
        fire.SetActive(!fire.activeSelf);
    }
}
