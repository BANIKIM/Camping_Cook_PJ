using UnityEngine;

public class Ignite : MonoBehaviour
{
    public GameObject _fireEffect;

    // ��ư�� ���� �� ȣ���� �޼���
    public void OnOffFire(bool isignite)
    {
        // fire ���� ������Ʈ�� Ȱ��ȭ ���¸� ���
        _fireEffect.SetActive(isignite);
    }
}
