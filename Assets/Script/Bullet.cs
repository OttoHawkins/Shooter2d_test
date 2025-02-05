using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // —корость пули

    void Update()
    {
        // ƒвигаем пулю вверх (или в другом направлении в зависимости от firePoint)
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    // ”ничтожаем пулю, если она выходит за пределы экрана
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // ”ничтожаем врага при столкновении с пулей
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);  // ”ничтожаем пулю
            Destroy(other.gameObject);  // ”ничтожаем врага
        }
    }
}
