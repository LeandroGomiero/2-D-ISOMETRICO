using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damagePerSecond = 5;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Certifique-se de que o jogador seja marcado corretamente na Unity
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerSecond);
            }
        }
    }
}
