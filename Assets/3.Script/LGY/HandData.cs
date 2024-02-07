using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{
    public enum Hand_Type
    {
        Left = 0,
        right
    }

    public Hand_Type hand_type;
    public Transform root;
    public Animator animator;
    public Transform[] fingerbones;


}
