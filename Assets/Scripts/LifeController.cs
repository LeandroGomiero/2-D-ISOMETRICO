using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public float maxHealth = 100f; // Quantidade máxima de vida
    private float currentHealth; // Vida atual

    private void Start()
    {
        currentHealth = maxHealth; // Configurar a vida atual para o valor máximo no início
    }

    // Método para causar dano à entidade (jogador ou javali)
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Verificar se a entidade está morta
        if (currentHealth <= 0)
        {
            Die(); // Implemente o método Die() para lidar com a morte
        }
    }

    // Método para tratar a morte da entidade
    private void Die()
    {
        // Implemente aqui as ações de morte, como destruir o objeto ou ativar alguma animação.
        // Por exemplo, para o javali, você pode tocar uma animação de morte e desativar o objeto.

        // Exemplo: gameObject.SetActive(false);
    }
}
