using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameStart()
    {
        UIManager.Instance.GameStart();
        ScoreManager.Instance.StartScore();
    }

    public void GameOver()
    {
        UIManager.Instance.GameOverUI();
        ScoreManager.Instance.StopScore();
        isGameOver = true;
    }

}
