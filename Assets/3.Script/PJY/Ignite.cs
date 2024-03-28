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

    // ��ư�� ���� �� ȣ���� �޼���
    public void OnOffFire(bool isignite)
    {
        // fire ���� ������Ʈ�� Ȱ��ȭ ���¸� ���

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
