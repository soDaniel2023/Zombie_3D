using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject GameOverPanel;
    public TMP_Text TopScore;
    public TMP_Text Score;
    public TMP_Text BestScore;
    public GameObject TapText;

    public static UIManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        StartPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        TapText.SetActive(true);
        TopScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void GameStart()
    {
        TapText.SetActive(false);
        StartPanel.SetActive(false);
    }

    public void GameOverUI()
    {
        GameOverPanel.SetActive(true);
        TapText.SetActive(true);

        Score.text = ScoreManager.Instance.Score.ToString();
        BestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        Animator anim = GameOverPanel.GetComponent<Animator>();
        if (anim != null)
            anim.enabled = false;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
