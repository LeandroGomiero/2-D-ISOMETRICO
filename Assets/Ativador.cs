using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativador : MonoBehaviour
{
    public KeyCode Key;
    bool active = false;
    GameObject note;
    private MinigameController minigameController;
    private AudioSource audioSource; // Referência ao AudioSource

    void Start()
    {
        // Buscar o controlador do minigame
        minigameController = FindObjectOfType<MinigameController>();

        // Pegar o AudioSource do GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Verifica se a tecla foi pressionada, a nota está ativa e ainda existe
        if (Input.GetKeyDown(Key) && active && note != null)
        {
            // Destruir a nota (gota de leite)
            Destroy(note);
            note = null;  // Certifica-se que a nota foi destruída

            // Adicionar pontuação ao destruir a nota
            if (minigameController != null)
            {
                minigameController.AddScore();
            }

            // Reproduzir o som de marcação de ponto
            if (audioSource != null)
            {
                audioSource.Play(); // Toca o áudio ao marcar ponto
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se colidir com um objeto que tenha a tag "Note", ativa a interação
        if (collision.gameObject.CompareTag("Note"))
        {
            active = true;
            note = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Apenas redefina se a nota ainda existir (não foi destruída)
        if (collision.gameObject.CompareTag("Note") && note != null)
        {
            active = false;
            note = null;
        }
    }
}

