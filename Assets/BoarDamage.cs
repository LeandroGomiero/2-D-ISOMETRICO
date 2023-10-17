using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarDamage : MonoBehaviour
{
    public int damagePerSecond = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damagePerSecond); // Causa dano ao jogador
        }
    }
}
