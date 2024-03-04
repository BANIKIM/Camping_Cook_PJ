using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUIManager : MonoBehaviour
{
    public GameObject Start;
    public GameObject Quit;
    public void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Box"))
        {
            Start.SetActive(true);
          
        }
        // ���� �浹�� ��ü�� �±װ� "Food"���
        else if (other.CompareTag("Food"))
        {
            Quit.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Day_test");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
