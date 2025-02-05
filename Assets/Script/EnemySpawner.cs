using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      
    public float spawnRate = 2f;       
    public Transform[] spawnPoints;    

    private float timer = 0f;          

    void Update()
    {
       
        timer += Time.deltaTime;

       
        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;  
        }
    }

    void SpawnEnemy()
    {
      
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
