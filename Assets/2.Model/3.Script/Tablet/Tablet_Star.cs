using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tablet_Star : MonoBehaviour
{
    private int[] _starCountArr = new int[5] { 0, 0, 0, 0, 0 };

    [SerializeField] private GameObject[] _starObj;
    [SerializeField] private Sprite _fillStarImg;

    public void StarUpdate(int idx)
    {
        // ������ ���� Ȱ��ȭ�� ��Ÿ�� ���� ��� (�ִ� 3������)
        // idx�� ���� Ȱ��ȭ�� ����
        // CookCheck�� �־����.
        if (_starCountArr[GameManager.instance._cookIdx] < idx)
        {
            GameManager.instance._star -= _starCountArr[GameManager.instance._cookIdx];
            for (int i = 0; i < idx; i++)
            {
                _starObj[GameManager.instance._cookIdx].transform.GetChild(i).GetComponent<Image>().sprite = _fillStarImg;
            }
            _starCountArr[GameManager.instance._cookIdx] = idx;
            GameManager.instance._star += idx;
            TabletManager.instance._starCountText.text = string.Format("{0:00}", GameManager.instance._star);
        }
    }
}
