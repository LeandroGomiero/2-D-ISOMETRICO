using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public TMP_Text healthText;
    public LifeBar lifeBar; // Adicione uma referência à barra de vida

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            // O jogador morreu, adicione o código para lidar com a morte do jogador aqui
            Debug.Log("O jogador morreu!");

            // Destruir o objeto do jogador
            Destroy(gameObject);
        }

        // Atualize a barra de vida
        UpdateLifeBar();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Vida: " + currentHealth.ToString();
        }
    }

    private void UpdateLifeBar()
    {
        if (lifeBar != null)
        {
            float healthRatio = (float)currentHealth / maxHealth;
            lifeBar.AlteraVida(healthRatio);
        }
    }
}
