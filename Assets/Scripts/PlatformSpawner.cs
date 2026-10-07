using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamand;

    private Vector3 lastPos;
    private float size;
    private bool spawningStopped = false;

    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
            SpawnPlatform();
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver && !spawningStopped)
        {
            spawningStopped = true;
            CancelInvoke(nameof(SpawnPlatform));
        }

        if (!spawningStopped)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null && (lastPos - player.transform.position).magnitude < 10f)
                SpawnPlatform();
        }
    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnPlatform), 0f, 0.5f);
    }

    void SpawnPlatform()
    {
        if (Random.Range(0, 6) <= 2) SpawnX();
        else SpawnZ();
    }

    void SpawnX()
    {
        lastPos += Vector3.right * size;
        CreatePlatform(lastPos);
    }

    void SpawnZ()
    {
        lastPos += Vector3.forward * size;
        CreatePlatform(lastPos);
    }

    void CreatePlatform(Vector3 pos)
    {
        GameObject plat = Instantiate(platform, pos, Quaternion.identity);

        if (Random.Range(0, 4) == 0)
            Instantiate(diamand, pos + Vector3.up, Quaternion.identity);

        if (plat.GetComponent<TriggerPlatform>() == null)
            plat.AddComponent<TriggerPlatform>();
    }
}
