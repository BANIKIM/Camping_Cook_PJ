using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUIManager : MonoBehaviour
{
    //싱글게임  시작 
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    //게임 종료
    public void QuitGame()
    {
        Application.Quit();
    }
}
