using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;  // Скорость движения игрока
    public float rotationSpeed = 200f; // Скорость вращения персонажа
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform gun;  // Ссылка на пушку игрока

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Движение игрока
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Вращение пушки в сторону курсора
        RotateGunTowardsMouse();

        // Вращение персонажа в направлении его движения
        RotatePlayer();

        // Стрельба
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * playerSpeed;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void RotateGunTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Позиция курсора
        Vector2 direction = (mousePos - gun.position).normalized; // Направление от пушки к курсору
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Вычисление угла
        gun.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Применяем вращение
    }

    void RotatePlayer()
    {
        if (moveInput.magnitude > 0)  // Если игрок двигается
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg; // Вычисление угла
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Вычисляем вращение
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);  // Вращаем персонажа
        }
    }
}
