using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasoning : MonoBehaviour
{
    [SerializeField] Meat meat;

    public enum SeasonType
    {
        sault, pepper
    }
   
    [SerializeField] ParticleSystem particle;

    public bool seasoning = false;
    public SeasonType seasonType;

    [Header("양념통과 고기 사이 간격")]
    public float lineSize = 1.5f;

    [Header("양념 뿌려지는 시간")]
    public float time = 0.8f;

    private void Start()
    {
        meat = FindObjectOfType<Meat>();
    }

    private void Update()
    {
        CheckMeat();
    }

    private void CheckMeat()
    {
        Debug.DrawRay(transform.position, transform.up * lineSize, Color.green);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up * lineSize, out hit, lineSize))
        {
            if(hit.collider.tag == "Meat_hdy")
            {
                seasoning = true;

                if(seasonType == SeasonType.sault)
                {
                    StartCoroutine(SaultOn());
                    meat.saulting = true;
                }
                else if (seasonType == SeasonType.pepper)
                {
                    StartCoroutine(PepperOn());
                    meat.peppering = true;
                }
               
            }
            
        }
    }

    IEnumerator SaultOn()
    {
        yield return new WaitForSeconds(0.1f);
        particle.Play();
       
        yield return new WaitForSeconds(time);
        particle.Stop();
    }

    IEnumerator PepperOn()
    {
        yield return new WaitForSeconds(0.1f);
        particle.Play();

        yield return new WaitForSeconds(time);
        particle.Stop();
    }

}
