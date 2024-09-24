using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // Ссылка на объект игрока
    public Vector3 offset;      // Смещение камеры относительно игрока
    public float smoothSpeed = 0.125f; // Скорость плавного следования камеры

    void LateUpdate()
    {
        // Желаемая позиция камеры
        Vector3 desiredPosition = player.position + offset;

        // Плавное перемещение камеры к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Устанавливаем новую позицию камеры
        transform.position = smoothedPosition;

        // Поворачиваем камеру, чтобы она всегда смотрела на игрока
        transform.LookAt(player);
    }
}
