using UnityEngine;

public class SummonEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            SetSpawnTimer();
        }
    }

    private void SetSpawnTimer()
    {
        spawnTimer = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
