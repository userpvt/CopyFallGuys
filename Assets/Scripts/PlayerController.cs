using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;        // Скорость движения
    public float jumpForce = 5.0f;        // Сила прыжка
    public float maxSpeed = 10.0f;        // Максимальная скорость, чтобы игрок не разгонялся слишком сильно
    public float drag = 5.0f;             // Коэффициент трения для плавного замедления

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;                   // Устанавливаем трение
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Создаем вектор направления движения
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // Добавляем движение, но не через AddForce, а через изменение скорости (это даст больше контроля)
        Vector3 newVelocity = movement * moveSpeed;
        Vector3 targetVelocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z); // Оставляем Y как есть для прыжка

        // Применяем к Rigidbody, но ограничиваем максимальную скорость
        rb.velocity = Vector3.ClampMagnitude(targetVelocity, maxSpeed);
    }

    void Jump()
    {
        // Прыжок происходит при нажатии на пробел, если игрок на земле (не в прыжке)
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
