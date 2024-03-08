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
        // 레벨에 따라 활성화할 스타의 개수 계산 (최대 3개까지)
        // idx는 별을 활성화할 개수
        // CookCheck에 넣어야함.
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
