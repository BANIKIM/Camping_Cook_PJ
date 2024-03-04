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
        // 만약 충돌한 객체의 태그가 "Food"라면
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
