using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hardware_Rig : MonoBehaviour
{
    public Hardware_Hand left_Hand; //왼손 
    public Hardware_Hand right_Hand; //오른손
    public Hardware_Head head_Set; //머리

    //Player 위치값
    public Vector3 player_Position; // 포지션값
    public Quaternion player_Rotation; // 회전값

    //왼손 위치값
    public Vector3 left_Hand_Position; // 포지션값
    public Quaternion left_Hand_Rotation; // 회전값

    //오른손 위치값
    public Vector3 right_Hand_Position; // 포지션값
    public Quaternion right_Hand_Rotation; // 회전값

    //헤드 위치값
    public Vector3 head_Set_Position;
    public Quaternion head_Set_Rotation;

    private void LateUpdate()
    {
        //Player 동기화
        player_Position = transform.position;
        player_Rotation = transform.rotation;
        //왼손 동기화
        left_Hand_Position = left_Hand.transform.position;
        left_Hand_Rotation = left_Hand.transform.rotation;
        //오른손 동기화
        right_Hand_Position = right_Hand.transform.position;
        right_Hand_Rotation = right_Hand.transform.rotation;
        //머리 동기화
        head_Set_Position = head_Set.transform.position;
        head_Set_Rotation = head_Set.transform.rotation;
    }
}
