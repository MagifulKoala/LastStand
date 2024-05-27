using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    SimpleTimer timer;
    public float spawnTime;
    public int simultaneosEnemySpawns;
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
        float xPos = Random.Range(bottomLeft.x, upperRight.x);
        float yPos = Random.Range(bottomLeft.y, upperRight.y);

        Vector3 spawnPoint = new Vector3(xPos, yPos, transform.position.z);

        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }
}
