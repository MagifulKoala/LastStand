using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    SimpleTimer timer;
    public float spawnTime;
    public int simultaneosEnemySpawns;
    public float radius = 0.5f;
    public LayerMask layerMask;

    bool timerFinished = false;

    private void Start()
    {
        timer = GetComponent<SimpleTimer>();
        timer.timerFinished.AddListener(TimerFinished);
    }


    private void Update()
    {
        handleEnemySpawn();
    }
    private void TimerFinished()
    {
        timerFinished = true;
    }

    void handleEnemySpawn()
    {
        timer.StartTimer(spawnTime);
        if (timerFinished)
        {
            spawnEnemies(simultaneosEnemySpawns);
            timerFinished = false;
        }
    }

    void spawnEnemies(int pEnemyAmount)
    {
        Renderer renderer = GetComponent<Renderer>();
        Vector3 spawnAreaSize = renderer.bounds.size;

        Vector3 bottomLeft = new Vector3(renderer.bounds.min.x, renderer.bounds.min.y, transform.position.z);
        Vector3 upperRight = new Vector3(renderer.bounds.max.x, renderer.bounds.max.y, transform.position.z);

        for (int i = 0; i < pEnemyAmount; i++)
        {
            spawnEnemy(bottomLeft, upperRight);
        }
    }

    private void spawnEnemy(Vector3 bottomLeft, Vector3 upperRight)
    {
        Vector3? spawnPoint = CreateSpawnPoint(bottomLeft, upperRight);
        //Debug.Log($"spanwPoint: {spawnPoint}");
        if (spawnPoint != null)
        {
            Instantiate(enemyPrefab, spawnPoint.Value, Quaternion.identity);
        }
    }

    int numberOfTries = 0;
    private Vector3? CreateSpawnPoint(Vector3 bottomLeft, Vector3 upperRight)
    {
        if (numberOfTries >= 3) { numberOfTries = 0; return null; }

        float xPos = Random.Range(bottomLeft.x, upperRight.x);
        float yPos = Random.Range(bottomLeft.y, upperRight.y);
        Vector3 spawnPoint = new Vector3(xPos, yPos, transform.position.z);

        if (CheckForPlayer(spawnPoint))
        {
            Debug.Log("player detected changing spawn");
            numberOfTries++;
            Debug.Log($"numberOfTries: {numberOfTries}");
            return CreateSpawnPoint(bottomLeft, upperRight);
        }
        else
        {
            numberOfTries = 0;
            return spawnPoint;
        }

    }

    private bool CheckForPlayer(Vector3 spawnPoint)
    {
        Vector2 point = new Vector2(spawnPoint.x, spawnPoint.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, layerMask);
        if (colliders.Length > 0)
        {
            foreach (Collider2D col in colliders)
            {
                if (col.gameObject.tag == "Player")
                {
                    return true;
                }
            }
        }
        return false;
    }
}
