using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrap : MonoBehaviour
{
    public float windForce = 10f;
    private Vector3 windDirection;

    void Start()
    {
        StartCoroutine(ChangeWindDirection());
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(windDirection * windForce);
            }
        }
    }

    // Меняем направление ветра каждые 2 секунды
    IEnumerator ChangeWindDirection()
    {
        while (true)
        {
            float angle = Random.Range(0f, 360f);
            windDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
            yield return new WaitForSeconds(2f);
        }
    }
}
