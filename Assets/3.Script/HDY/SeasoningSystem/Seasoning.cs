using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasoning : MonoBehaviour
{
    public enum Season_Type
    {
        salt = 0, 
        pepper,
    }

    [SerializeField] private ParticleSystem particle;

    [SerializeField] private Season_Type season_type;

    [Header("양념통과 고기 사이 간격")]
    [SerializeField] private float lineSize = 1.5f;

    [Header("양념 뿌려지는 시간")]
    [SerializeField] private WaitForSeconds cool = new WaitForSeconds(0.8f);

    private IEnumerator OnSeasoning_Temp;

    private void FixedUpdate()
    {
        CheckMeat();
    }

    private void CheckMeat()
    {
        Debug.DrawRay(transform.position, transform.up * lineSize, Color.green);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up * lineSize, out hit, lineSize))
        {
            if (hit.collider.gameObject.layer.Equals(6))
            {
                Seasoning_Ingredient seasoning_ingred = hit.collider.gameObject.GetComponent<Seasoning_Ingredient>();


                OnSeasoning();
                seasoning_ingred.AddSeasoning((int)season_type);

            }
        }
    }

    private void OnSeasoning()
    {
        OnSeasoning_Temp = OnSeasoning_co();
        StartCoroutine(OnSeasoning_Temp);
    }

    IEnumerator OnSeasoning_co()
    {
        yield return new WaitForSeconds(0.1f);
        particle.Play();

        yield return cool;
        particle.Stop();
    }
}
