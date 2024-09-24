using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
private Renderer trapRenderer;
    private Color originalColor;
    private Color orangeColor = new Color(1f, 0.5f, 0f); // Оранжевый цвет (RGB: 255, 128, 0)

    private bool isActivated = false;
    private float activationTime = 1f;
    private float resetTime = 5f;
    private float damageTime = 0f;
    private bool damageDealt = false; // Чтобы предотвратить повторное нанесение урона

    public int damageAmount = 30; // Урон от ловушки

    void Start()
    {
        trapRenderer = GetComponent<Renderer>();
        originalColor = trapRenderer.material.color;
    }

    void Update()
    {
        if (isActivated)
        {
            damageTime += Time.deltaTime;

            if (damageTime >= activationTime && !damageDealt)
            {
                trapRenderer.material.color = Color.red; // Меняем цвет на красный при нанесении урона
                
                // Наносим урон игроку
                DealDamageToPlayer();

                // Перезаряжаем ловушку через определенное время
                Invoke("ResetTrap", resetTime);
                damageDealt = true; // Урон нанесен
                isActivated = false; // Деактивируем ловушку
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true;
            trapRenderer.material.color = orangeColor; // Цвет оранжевый при активации
            damageTime = 0f;
            damageDealt = false; // Ловушка готова нанести урон
        }
    }

    private void DealDamageToPlayer()
    {
        // Находим объект игрока по тегу "Player"
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Наносим урон
            }
        }
    }

    private void ResetTrap()
    {
        trapRenderer.material.color = originalColor; // Возвращаем цвет платформы к исходному
        isActivated = false;
        damageDealt = false; // Ловушка готова к повторному использованию
    }
}
