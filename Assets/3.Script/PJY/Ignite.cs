using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ignite : MonoBehaviour
{
    public GameObject _fireEffect;
    public XRGrabInteractable a;
    public AudioSource OnIgnite;

    private void FixedUpdate()
    {
        if (!a.isSelected) _fireEffect.SetActive(false);
    }
    // 버튼을 누를 때 호출할 메서드
    public void OnOffFire(bool isignite)
    {
        // fire 게임 오브젝트의 활성화 상태를 토글

        _fireEffect.SetActive(isignite);
        if (isignite)
        {
            OnIgnite.Play();
        }
        else
        {
            OnIgnite.Stop();
        }
        
    }
}
