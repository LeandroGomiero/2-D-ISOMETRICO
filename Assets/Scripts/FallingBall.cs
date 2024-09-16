using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour
{
    private MinigameController minigameController;

    void Start()
    {
        minigameController = FindObjectOfType<MinigameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bolinha entrou no Trigger da bolinha com Tag "KeyA"
        if (other.CompareTag("KeyA"))
        {
            // Verifica se o jogador pressionou 'A' no momento da colisão
            if (Input.GetKeyDown(KeyCode.A))
            {
                minigameController.AddScore();  // Adiciona ponto
                Destroy(gameObject);  // Destroi a bolinha após pontuar
            }
        }
        // Verifica se a bolinha entrou no Trigger da bolinha com Tag "KeyD"
        else if (other.CompareTag("KeyD"))
        {
            // Verifica se o jogador pressionou 'D' no momento da colisão
            if (Input.GetKeyDown(KeyCode.D))
            {
                minigameController.AddScore();  // Adiciona ponto
                Destroy(gameObject);  // Destroi a bolinha após pontuar
            }
        }
    }
}
