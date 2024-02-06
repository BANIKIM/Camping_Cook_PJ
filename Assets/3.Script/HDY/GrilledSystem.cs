using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrilledSystem : MonoBehaviour
{
    public Material[] mat = new Material[3];
    //private int i = 1;

    public float time = 0f;
    public float radius = 0f;
    private bool turn = false;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat[0];
    }
    private void Update()
    {
        MoreGrill();

    }

    private void MoreGrill()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("GrillGrate"))
            {
                //Debug.Log("�׸� �±� ������");

                time += Time.deltaTime;

                if (time >= 8)
                {
                    Debug.Log("turn����1 " + turn);
                    gameObject.GetComponent<MeshRenderer>().material = mat[1];
                }
                
                //�̰� ����
                if (time > 10)
                {
                    Debug.Log("turn����2 " + turn);
                    gameObject.GetComponent<MeshRenderer>().material = mat[2];
                }
            }

        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("GrillGrate"))
        {
            time = 0f;
        }
    }

    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("GrillGrate"))
    //    {

    //    }
    //}

    //private void OnCollisionStay(Collision col)
    //{
    //    if (col.gameObject.CompareTag("GrillGrate"))
    //    {
    //        time += Time.deltaTime;

    //        if (gameObject.GetComponent<MeshRenderer>().material == mat[0])
    //        {
    //            Debug.Log("�����");
    //        }
    //        if (gameObject.GetComponent<MeshRenderer>().material == mat[1])
    //        {
    //            Debug.Log("������");
    //        }
    //        if (gameObject.GetComponent<MeshRenderer>().material == mat[2])
    //        {
    //            Debug.Log("ź���");
    //        }

    //    }
    //}
}
