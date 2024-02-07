using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skewer : MonoBehaviour
{
    [SerializeField] private List<Transform> stickpos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(6) && !stickpos.Count.Equals(0))
        {
            Skewer_Ingredient skewer_ingred = other.gameObject.GetComponent<Skewer_Ingredient>();
            skewer_ingred.Change_Skewer_State(Skewer_State.Inserted);

            other.gameObject.transform.position = stickpos[0].position;        // ��ġ�� ����
            other.gameObject.transform.parent = gameObject.transform;     // ��ġ�� ���
            stickpos.RemoveAt(0);
        }
    }
}
