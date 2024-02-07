using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hardware_Rig : MonoBehaviour
{
    public Hardware_Hand left_Hand; //�޼� 
    public Hardware_Hand right_Hand; //������
    public Hardware_Head head_Set; //�Ӹ�

    //Player ��ġ��
    public Vector3 player_Position; // �����ǰ�
    public Quaternion player_Rotation; // ȸ����

    //�޼� ��ġ��
    public Vector3 left_Hand_Position; // �����ǰ�
    public Quaternion left_Hand_Rotation; // ȸ����

    //������ ��ġ��
    public Vector3 right_Hand_Position; // �����ǰ�
    public Quaternion right_Hand_Rotation; // ȸ����

    //��� ��ġ��
    public Vector3 head_Set_Position;
    public Quaternion head_Set_Rotation;

    private void LateUpdate()
    {
        //Player ����ȭ
        player_Position = transform.position;
        player_Rotation = transform.rotation;
        //�޼� ����ȭ
        left_Hand_Position = left_Hand.transform.position;
        left_Hand_Rotation = left_Hand.transform.rotation;
        //������ ����ȭ
        right_Hand_Position = right_Hand.transform.position;
        right_Hand_Rotation = right_Hand.transform.rotation;
        //�Ӹ� ����ȭ
        head_Set_Position = head_Set.transform.position;
        head_Set_Rotation = head_Set.transform.rotation;
    }
}
