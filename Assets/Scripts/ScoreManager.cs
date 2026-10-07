using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int Score;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }

    void IncrementScore()
    {
        Score++;
        PlayerPrefs.SetInt("Score", Score);
        if (UIManager.Instance != null)
            UIManager.Instance.Score.text = Score.ToString();
    }

    public void StartScore()
    {
        InvokeRepeating(nameof(IncrementScore), 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke(nameof(IncrementScore));
        PlayerPrefs.SetInt("Score", Score);

        if (!PlayerPrefs.HasKey("BestScore") || Score > PlayerPrefs.GetInt("BestScore"))
            PlayerPrefs.SetInt("BestScore", Score);

        if (UIManager.Instance != null)
            UIManager.Instance.BestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
