using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoostItem : MonoBehaviour
{
    public float healthBoost = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(-healthBoost);
        }
    }
}
