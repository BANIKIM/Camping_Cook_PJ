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
        if (fountain) rigid.AddForce(Vector3.up * randomForce);//�����ǰ� ���� Ƣ���
        randomTime = Random.Range(1, 2);//������ �ð�����
    }

    private void Update()
    {
        if (!isFire) currentTime += Time.deltaTime;

        if (randomTime < currentTime)
        {
            isFire = true;
            int _num = Random.Range(0, firework.Length);
            rigid.isKinematic = true;
            firework[_num].SetActive(true); //�������� �ٸ� ����Ʈ�� ����
            currentTime = 0f;
            Destroy(gameObject, 8f);
        }
    }
}
