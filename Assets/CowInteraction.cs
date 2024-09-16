using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necessário para gerenciar cenas

public class CowInteraction : MonoBehaviour
{
    private bool canInteract = false;

    void Start()
    {
        // Nenhuma mudança necessária no Start
    }

    void Update()
    {
        // Verifica se todos os itens foram coletados
        if (CheckItemsCollected())
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o jogador está colidindo com a vaca e se todos os itens foram coletados
        if (other.CompareTag("Player") && canInteract)
        {
            // Carrega a nova cena, por exemplo, o minigame
            ChangeToMinigameScene();
        }
    }

    // Função para verificar se todos os itens foram coletados
    bool CheckItemsCollected()
    {
        // Busca todos os objetos com o script ItemInteraction
        ItemInteraction[] remainingItems = FindObjectsOfType<ItemInteraction>();

        // Se não houver mais itens restantes, retorna true
        return remainingItems.Length == 0;
    }

    // Função para trocar para a cena do minigame
    void ChangeToMinigameScene()
    {
        // Nome da cena que será carregada. Certifique-se de que essa cena esteja no Build Settings.
        string sceneName = "MinigameScene"; // Altere para o nome correto da sua cena

        // Carrega a nova cena
        SceneManager.LoadScene(sceneName);
    }
}
