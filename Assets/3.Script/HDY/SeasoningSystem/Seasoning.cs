using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SeasonType
{
    salt = 0,
    pepper,
}

public class Seasoning : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private ParticleSystem particle;

    [SerializeField] private SeasonType seasonType;

    [Header("양념통과 고기 사이 간격")]
    [SerializeField] private float lineSize = 0.5f;

    bool isAct = false;
    [Header("양념 뿌려지는 시간")]
    [SerializeField] private WaitForSeconds cool = new WaitForSeconds(0.3f);

    private IEnumerator OnSeasoningTemp;

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
                SeasoningIngredient _seasoningingred = hit.collider.gameObject.GetComponent<SeasoningIngredient>();

                if (!isAct)
                {
                    OnSeasoning();
                    _seasoningingred.AddSeasoning(seasonType);
                }
            }
        }
    }

    private void OnSeasoning()
    {
        OnSeasoningTemp = OnSeasoning_co();
        StartCoroutine(OnSeasoningTemp);
    }

    IEnumerator OnSeasoning_co()
    {
        isAct = true;
        
        yield return new WaitForSeconds(0.1f);
        particle.Play();

        audioSource.PlayOneShot(audioSource.clip);

        yield return cool;
        particle.Stop();
        isAct = false;
        yield return null;
    }
}
