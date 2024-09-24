using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformTrap : MonoBehaviour
{
    private Rigidbody rb;
    public LevelManager levelManager; // Ссылка на LevelManager

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Платформа не падает сразу
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fall(); // Сразу вызываем метод падения
            StartCoroutine(PlayerDeathDelay(other.gameObject)); // Запускаем корутину для отсрочки смерти
        }
    }

    void Fall()
    {
        rb.isKinematic = false; // Платформа начинает падать
    }

    IEnumerator PlayerDeathDelay(GameObject player)
    {
        yield return new WaitForSeconds(0.5f); // Ожидание 0.5 секунды
        levelManager.EndGame(false, "Вы упали в лаву!"); // Игрок умирает
    }
    // private Rigidbody rb;
    // public LevelManager levelManager; // Ссылка на LevelManager

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     rb.isKinematic = true; // Платформа не падает сразу
    // }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         Fall(); // Сразу вызываем метод падения
    //         levelManager.EndGame(false, "Вы упали в лаву!"); // Игрок умирает
    //     }
    // }

    // void Fall()
    // {
    //     rb.isKinematic = false; // Платформа начинает падать
    // }
    // private Rigidbody rb;

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     rb.isKinematic = true; // Платформа не падает сразу
    // }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         Fall(); // Сразу вызываем метод падения
    //     }
    // }

    // void Fall()
    // {
    //     rb.isKinematic = false; // Платформа начинает падать
    // }
}
