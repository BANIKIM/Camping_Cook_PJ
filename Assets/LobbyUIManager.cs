using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUIManager : MonoBehaviour
{
    //�̱۰���  ���� 
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    //���� ����
    public void QuitGame()
    {
        Application.Quit();
    }
}
