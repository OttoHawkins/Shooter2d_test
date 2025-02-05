using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // Префаб врага
    public float spawnRate = 2f;        // Интервал спавна
    public Transform[] spawnPoints;     // Массив точек спавна

    private float timer = 0f;           // Таймер для отсчета времени между спавнами

    void Update()
    {
        // Увеличиваем таймер на время, прошедшее с последнего кадра
        timer += Time.deltaTime;

        // Если таймер превышает интервал, спавним врага и сбрасываем таймер
        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;  // Сброс таймера
        }
    }

    void SpawnEnemy()
    {
        // Рандомно выбираем точку спавна
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
