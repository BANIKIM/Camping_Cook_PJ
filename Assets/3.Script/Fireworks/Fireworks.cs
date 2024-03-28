using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public GameObject[] firework;
    private Rigidbody rigid;
    public float randomTime;
    public float currentTime = 0f;
    private bool isFire = false;
    public bool fountain;
    private int randomForce;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        randomForce = Random.Range(900, 1100);
        if (fountain) rigid.AddForce(Vector3.up * randomForce);//생성되고 위로 튀어간다
        randomTime = Random.Range(1, 2);//터지는 시간랜덤
    }

    private void Update()
    {
        if (!isFire) currentTime += Time.deltaTime;

        if (randomTime < currentTime)
        {
            isFire = true;
            int _num = Random.Range(0, firework.Length);
            rigid.isKinematic = true;
            firework[_num].SetActive(true); //랜덤으로 다른 이펙트가 터짐
            currentTime = 0f;
            Destroy(gameObject, 8f);
        }
    }
}
