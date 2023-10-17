using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public float maxHealth = 100f; // Quantidade m�xima de vida
    private float currentHealth; // Vida atual

    private void Start()
    {
        currentHealth = maxHealth; // Configurar a vida atual para o valor m�ximo no in�cio
    }

    // M�todo para causar dano � entidade (jogador ou javali)
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Verificar se a entidade est� morta
        if (currentHealth <= 0)
        {
            Die(); // Implemente o m�todo Die() para lidar com a morte
        }
    }

    // M�todo para tratar a morte da entidade
    private void Die()
    {
        // Implemente aqui as a��es de morte, como destruir o objeto ou ativar alguma anima��o.
        // Por exemplo, para o javali, voc� pode tocar uma anima��o de morte e desativar o objeto.

        // Exemplo: gameObject.SetActive(false);
    }
}
