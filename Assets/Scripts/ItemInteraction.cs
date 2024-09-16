using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    
    public string itemDescription;  // Descrição que será exibida ao interagir
    public GameObject dialogueBox;  // Caixa de diálogo no Canvas
    public Text dialogueText;  // Texto dentro do diálogo
    public GameObject interactionPrompt;  // Texto para "Pressione E para interagir"
    private bool isPlayerNear = false;  // Verifica se o jogador está perto
    private bool hasCollected = false;  // Verifica se o item foi coletado

    void Start()
    {
        interactionPrompt.SetActive(false);  // Deixa o prompt desativado no início
    }

    void Update()
    {
        // Verifica se o jogador está próximo e se a tecla de ação é pressionada
        if (isPlayerNear && !hasCollected && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tecla E pressionada, exibindo descrição do item.");
            ShowItemDescription();
        }

        // Verifica se o diálogo está ativo e se o jogador quer coletar o item
        if (dialogueBox.activeSelf && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Tecla C pressionada, item coletado.");
            CollectItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;  // Jogador está próximo
            interactionPrompt.SetActive(true);  // Exibe a mensagem de interação
            Debug.Log("Jogador entrou na área do item: " + gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;  // Jogador se afastou
            interactionPrompt.SetActive(false);  // Esconde a mensagem de interação
            Debug.Log("Jogador saiu da área do item: " + gameObject.name);
            HideItemDescription();
        }
    }

    void ShowItemDescription()
    {
        dialogueBox.SetActive(true);  // Ativa a caixa de diálogo
        dialogueText.text = itemDescription;  // Exibe a descrição do item
        interactionPrompt.SetActive(false);  // Esconde o prompt de interação
        Debug.Log("Descrição do item exibida: " + itemDescription);
    }

    void HideItemDescription()
    {
        dialogueBox.SetActive(false);  // Desativa a caixa de diálogo
        Debug.Log("Descrição do item ocultada.");
    }

    void CollectItem()
    {
        hasCollected = true;  // Marca o item como coletado
        HideItemDescription();  // Esconde o diálogo
        Debug.Log("Item coletado e destruído: " + gameObject.name);
        Destroy(gameObject);  // Destrói o item da cena
    }
}