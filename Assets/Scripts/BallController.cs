using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool GameOver;

    public GameObject Particle;
    private bool started = false;
    private bool gameOverCalled = false;

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.right;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 5f))
        {
            if (!gameOverCalled)
            {
                gameOverCalled = true;
                GameOver = true;
                rb.linearVelocity = new Vector3(0, -25f, 0);
                Camera.main.GetComponent<CameraFollow>().GameOver = true;
                GameManager.Instance.GameOver();
                UIManager.Instance.GameOverUI();
            }
            return;
        }

        if (!started && Input.GetMouseButtonDown(0))
        {
            started = true;
            GameManager.Instance.GameStart();
            FindFirstObjectByType<PlatformSpawner>().StartSpawning();
        }

        if (!GameOver && started)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                moveDirection = Vector3.forward;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                moveDirection = Vector3.right;

            rb.linearVelocity = moveDirection.normalized * speed;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Diamand"))
        {
            GameObject p = Instantiate(Particle, col.transform.position, Quaternion.identity);
            Destroy(p, 1f);
            Destroy(col.gameObject);

            ScoreManager.Instance.Score += 1;
            PlayerPrefs.SetInt("Score", ScoreManager.Instance.Score);

            if (UIManager.Instance != null)
                UIManager.Instance.Score.text = ScoreManager.Instance.Score.ToString();
        }
    }
}
