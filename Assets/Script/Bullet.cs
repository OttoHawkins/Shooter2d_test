using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 

    void Update()
    {
     
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);  
            Destroy(other.gameObject); 
        }
    }
}
