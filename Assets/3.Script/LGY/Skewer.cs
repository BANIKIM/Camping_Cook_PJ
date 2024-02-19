using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skewer : MonoBehaviour
{
    [SerializeField] private List<Transform> _stickpos;
    [SerializeField] private LayerMask _cookLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(_cookLayer) && !_stickpos.Count.Equals(0))
        {
            Skewer_Ingredient skewer_ingred = other.gameObject.GetComponent<Skewer_Ingredient>();
            skewer_ingred.Change_Skewer_State(Skewer_State.Inserted);

            other.gameObject.transform.position = _stickpos[0].position;        // ��ġ�� ����
            other.gameObject.transform.parent = gameObject.transform;     // ��ġ�� ���
            _stickpos.RemoveAt(0);
        }
    }
}
