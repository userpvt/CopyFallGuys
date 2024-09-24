using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacleTrap : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 pushDirection = other.transform.position - transform.position;
                rb.AddForce(pushDirection.normalized * 500f); // Сильный толчок
            }
        }
    }
}
