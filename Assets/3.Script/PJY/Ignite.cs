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
    // ��ư�� ���� �� ȣ���� �޼���
    public void OnOffFire(bool isignite)
    {
        // fire ���� ������Ʈ�� Ȱ��ȭ ���¸� ���

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
