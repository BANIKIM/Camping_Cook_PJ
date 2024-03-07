using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tablet_RealTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _realTimeText;
    private DateTime _now = DateTime.Now;

    private void FixedUpdate()
    {
        _realTimeText.text = _now.ToString("h : mm tt");
    }
}
