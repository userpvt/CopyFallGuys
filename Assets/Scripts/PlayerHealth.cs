using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;    // Максимальное здоровье
    public int currentHealth;      // Текущее здоровье
    public TextMeshProUGUI healthText; // UI элемент для отображения здоровья
    public LevelManager levelManager; // Ссылка на LevelManager

    void Start()
    {
        // Устанавливаем здоровье на максимум
        currentHealth = maxHealth;

        // Обновляем UI здоровья при старте
        UpdateHealthUI();
    }

    // Метод для нанесения урона
    public void TakeDamage(int damage)
    {
        // Вычитаем урон из текущего здоровья
        currentHealth -= damage;

        // Убедимся, что текущее здоровье не становится меньше нуля
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // Обновляем UI после изменения здоровья
        UpdateHealthUI();

        // Если здоровье упало до нуля, вызываем метод поражения
        if (currentHealth == 0)
        {
            levelManager.EndGame(false, "Здоровье закончилось!");
        }
    }

    // Метод для обновления UI здоровья
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Здоровье: " + currentHealth.ToString();
        }
    }
}
