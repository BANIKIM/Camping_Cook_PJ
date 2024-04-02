using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TabletMahine : MonoBehaviour
{
    public enum TabletMod { Secret, Handed, World }

    private TabletMod _tabletMod;

    public InputActionReference HandCanvas;

    public GameObject _tablet;
    public GameObject TruePosition;

    public GameObject _hand;

    private IEnumerator _changeMod;
    private IEnumerator _pressYBtnTemp;

    private float _pressTime = 0f;
    private bool isPress = false;

    private void Awake()
    {
        DefaultSetting();
    }
    private void OnEnable()
    {
        //
        HandCanvas.action.started += OnButtonPress;
        HandCanvas.action.canceled += OnButtonRelease;
    }

    private void OnDisable()
    {
        HandCanvas.action.started -= OnButtonPress;
        HandCanvas.action.canceled -= OnButtonRelease;
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        isPress = true;

        switch (_tabletMod)
        {
            case TabletMod.Secret:
                PressYBtn();
                break;
            case TabletMod.Handed:
            case TabletMod.World:
                DefaultSetting();
                break;
            default:
                break;
        }
    }

    // 기본 셋팅
    private void DefaultSetting()
    {
        _tabletMod = TabletMod.Secret;   // 숨김 모드
        _tablet.SetActive(false);
        _tablet.transform.parent = _hand.transform;
    }

    private void OnButtonRelease(InputAction.CallbackContext context)
    {
        isPress = false;
        _pressTime = 0f;
    }

    private void PressYBtn()
    {
        _pressYBtnTemp = PressYBtn_co();
        StartCoroutine(_pressYBtnTemp);
    }

    private IEnumerator PressYBtn_co()
    {
        while (isPress && _pressTime < 1f)
        {

            _pressTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        _changeMod = _pressTime >= 1 ? WorldTablet_co() : HandedTablet_co();
        StartCoroutine(_changeMod);
        yield return null;
    }

    // 잡기 모드
    private IEnumerator HandedTablet_co()
    {       
        _tabletMod = TabletMod.Handed;   // 모드 변경
        _tablet.transform.localPosition = Vector3.zero;  // 포지션 초기화
        _tablet.transform.rotation = _hand.transform.rotation; // 캔버스2의 회전
        _tablet.SetActive(true);
        yield return null;
    }

    // 월드 모드
    private IEnumerator WorldTablet_co()
    {
        _tabletMod = TabletMod.World;
        _tablet.transform.localPosition = Vector3.zero;
        _tablet.transform.rotation = _hand.transform.rotation; // 캔버스2의 회전
        while (_tablet.transform.parent != null)
        {
            _tablet.transform.parent = null;
            yield return null;
        }
        _tablet.SetActive(true);

        yield return null;
    }



}
