using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUIManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Day_test");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
