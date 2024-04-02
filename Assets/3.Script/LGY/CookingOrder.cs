using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CookingOrder : MonoBehaviour
{
    public enum Tool_Idx
    {
        Pepper = 0,
        CampFire,
        Grill,
        Knife,
        Plate,
        Pot,
        Salt,
        Scoop,
        Skewer,
        Tongs,
    }

    public Image[] _line1;
    public Image[] _line2;
    public Image[] _line3;
    public Image[] _line4;
    public Image[] _line5;

    public Sprite[] _allImgs;

    public void DefaultSetting()
    {
        for (int i = 0; i < _line1.Length; i++)
        {
            _line1[i].transform.gameObject.SetActive(false);
            _line2[i].transform.gameObject.SetActive(false);
            _line3[i].transform.gameObject.SetActive(false);
            _line4[i].transform.gameObject.SetActive(false);
            _line5[i].transform.gameObject.SetActive(false);
        }
    }

    private void ImageActive(Image[] imgs, int[] idxArr)
    {
        for (int i = 0; i < idxArr.Length; i++)
        {
            imgs[i].sprite = _allImgs[idxArr[i]];
            imgs[i].transform.gameObject.SetActive(true);
        }
    }

}
