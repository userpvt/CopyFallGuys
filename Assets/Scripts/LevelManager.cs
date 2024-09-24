using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Для работы с UI
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI victoryText; // Текст победы
    public TextMeshProUGUI timeText;    // Текст времени
    public TextMeshProUGUI gameOverText; // Текст поражения
    public GameObject victoryScreen;    // Экран победы
    public GameObject gameOverScreen;   // Экран поражения
    public Transform finishLine;        // Финишная прямая
    public Transform playerTransform;   // Позиция игрока
    public GameObject restartButton;    // Кнопка перезапуска

    private float startTime;            // Время старта уровня
    private bool isGameActive = true;   // Флаг, что игра идет

    void Start()
    {
        // Прячем экраны победы и поражения
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        restartButton.SetActive(false); // Скрываем кнопку перезапуска
        startTime = Time.time; // Запоминаем время начала игры
    }

    void Update()
    {
        if (isGameActive)
        {
            // Обновляем текст времени
            float timeElapsed = Time.time - startTime;
            timeText.text = "Время: " + timeElapsed.ToString("F2") + " сек";

            // Проверка, упал ли игрок с платформы
            if (playerTransform.position.y < -5)
            {
                EndGame(false, "Вы упали с платформы!");
            }

            // Проверка, пересек ли игрок финишную прямую
            if (playerTransform.position.z >= finishLine.position.z)
            {
                EndGame(true, null); // Победа
            }
        }
    }

    // Метод для завершения игры (победа/поражение)
    public void EndGame(bool isVictory, string reason)
    {
        isGameActive = false;

        if (isVictory)
        {
            victoryScreen.SetActive(true);
            victoryText.text = "Победа! Время: " + (Time.time - startTime).ToString("F2") + " сек";
        }
        else
        {
            gameOverScreen.SetActive(true);
            gameOverText.text = "Поражение! " + reason;
        }

        restartButton.SetActive(true); // Показываем кнопку перезапуска

        // Останавливаем время
        Time.timeScale = 0f;
    }

    // Перезапуск игры
    public void RestartGame()
    {
        // Возвращаем время к нормальному значению
        Time.timeScale = 1f;

        // Перезапускаем текущий уровень
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
