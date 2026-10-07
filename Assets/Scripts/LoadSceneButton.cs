using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Ball()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Lobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
