using UnityEngine;

public class FirecrackerLaunch : MonoBehaviour
{
    public GameObject firecrackerObj;
    public Transform firecrackerPos;
    public float currentTime;
    public int randomTime;

    private void Start()
    {
        randomTime = Random.Range(1, 3);
    }

    void Update()
    {
        if (transform.GetComponentInParent<FireworkFiring>().isFiring)
        {
            currentTime += Time.deltaTime;
            if (randomTime < currentTime)
            {
                Instantiate(firecrackerObj, firecrackerPos);
                currentTime = 0;
            }
        }
    }
}
