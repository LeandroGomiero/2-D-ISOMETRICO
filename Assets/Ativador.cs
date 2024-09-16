using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativador : MonoBehaviour
{
    public KeyCode Key;
    bool active = false;
    GameObject note;
    private MinigameController minigameController;
    private AudioSource audioSource; // Refer�ncia ao AudioSource

    void Start()
    {
        // Buscar o controlador do minigame
        minigameController = FindObjectOfType<MinigameController>();

        // Pegar o AudioSource do GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(Key) && active && note != null)
        {
            Destroy(note);
            note = null;

            // Adicionar pontua��o ao destruir a nota
            if (minigameController != null)
            {
                minigameController.AddScore();
            }

            // Reproduzir o som de marca��o de ponto
            if (audioSource != null)
            {
                audioSource.Play(); // Toca o �udio ao marcar ponto
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note"))
        {
            active = true;
            note = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note"))
        {
            active = false;
            note = null;
        }
    }
}
