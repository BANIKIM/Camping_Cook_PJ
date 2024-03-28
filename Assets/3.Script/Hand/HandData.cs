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

    public HandType handType;
    public Transform root;
    public Animator animator;
    public Transform[] fingerBones;
}
