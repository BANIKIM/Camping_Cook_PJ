using UnityEngine;

public class Ignite : MonoBehaviour
{
    public GameObject _fireEffect;

    // 버튼을 누를 때 호출할 메서드
    public void OnOffFire(bool isignite)
    {
        // fire 게임 오브젝트의 활성화 상태를 토글
        _fireEffect.SetActive(isignite);
    }
}
