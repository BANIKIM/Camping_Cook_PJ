using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Season_Type
{
    salt = 0,
    pepper,
}

public class Seasoning : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;

    [SerializeField] private ParticleSystem particle;

    [SerializeField] private Season_Type season_type;

    [Header("양념통과 고기 사이 간격")]
    [SerializeField] private float lineSize = 0.5f;

    bool isAct = false;
    [Header("양념 뿌려지는 시간")]
    [SerializeField] private WaitForSeconds cool = new WaitForSeconds(0.3f);

    private IEnumerator OnSeasoning_Temp;

    private void FixedUpdate()
    {
        CheckMeat();
    }

    private void CheckMeat()
    {
        Debug.DrawRay(transform.position, transform.up * lineSize, Color.green);

        if (Physics.Raycast(transform.position, transform.up * lineSize, out RaycastHit hit, lineSize))
        {
            if (hit.collider.gameObject.layer == 6) // tobo_mh 이퀄 ==6 으로 수정
            {
                Seasoning_Ingredient seasoning_ingred = hit.collider.gameObject.GetComponent<Seasoning_Ingredient>();

                if (!isAct)
                {
                    OnSeasoning();
                    seasoning_ingred.AddSeasoning(season_type);
                }
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
        isAct = true;
        
        yield return new WaitForSeconds(0.1f);
        particle.Play();

        _audiosource.PlayOneShot(_audiosource.clip);
        //AudioManager.instance.Play_Audio(_source, (int)SFX_List.Seasoning);

        yield return cool;
        particle.Stop();
        isAct = false;
        yield return null;
    }
}
