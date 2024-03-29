using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{
    public enum HandType
    {
        Left = 0,
        Right,
    }

    public HandType _handType;
    public Transform _root;
    public Animator _animator;
    public Transform[] _fingerBones;



}
