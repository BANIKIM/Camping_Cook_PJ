using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ignite : MonoBehaviour
{
    public GameObject _fireEffect;
    public XRGrabInteractable _grabInteractable;
    public AudioSource _audioSource;

    private void FixedUpdate()
    {
        if (!_grabInteractable.isSelected)
        {
            _fireEffect.SetActive(false);
            _audioSource.Stop();
        }
          
    }

    // 버튼을 누를 때 호출할 메서드
    public void OnOffFire(bool isignite)
    {
        // fire 게임 오브젝트의 활성화 상태를 토글

        _fireEffect.SetActive(isignite);
        _audioSource.Play();

        if (isignite)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
        
    }
}
