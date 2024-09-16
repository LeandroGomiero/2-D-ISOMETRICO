using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    
    public string itemDescription;  // Descri��o que ser� exibida ao interagir
    public GameObject dialogueBox;  // Caixa de di�logo no Canvas
    public Text dialogueText;  // Texto dentro do di�logo
    public GameObject interactionPrompt;  // Texto para "Pressione E para interagir"
    private bool isPlayerNear = false;  // Verifica se o jogador est� perto
    private bool hasCollected = false;  // Verifica se o item foi coletado

    void Start()
    {
        interactionPrompt.SetActive(false);  // Deixa o prompt desativado no in�cio
    }

    void Update()
    {
        // Verifica se o jogador est� pr�ximo e se a tecla de a��o � pressionada
        if (isPlayerNear && !hasCollected && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tecla E pressionada, exibindo descri��o do item.");
            ShowItemDescription();
        }

        // Verifica se o di�logo est� ativo e se o jogador quer coletar o item
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
            isPlayerNear = true;  // Jogador est� pr�ximo
            interactionPrompt.SetActive(true);  // Exibe a mensagem de intera��o
            Debug.Log("Jogador entrou na �rea do item: " + gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;  // Jogador se afastou
            interactionPrompt.SetActive(false);  // Esconde a mensagem de intera��o
            Debug.Log("Jogador saiu da �rea do item: " + gameObject.name);
            HideItemDescription();
        }
    }

    void ShowItemDescription()
    {
        dialogueBox.SetActive(true);  // Ativa a caixa de di�logo
        dialogueText.text = itemDescription;  // Exibe a descri��o do item
        interactionPrompt.SetActive(false);  // Esconde o prompt de intera��o
        Debug.Log("Descri��o do item exibida: " + itemDescription);
    }

    void HideItemDescription()
    {
        dialogueBox.SetActive(false);  // Desativa a caixa de di�logo
        Debug.Log("Descri��o do item ocultada.");
    }

    void CollectItem()
    {
        hasCollected = true;  // Marca o item como coletado
        HideItemDescription();  // Esconde o di�logo
        Debug.Log("Item coletado e destru�do: " + gameObject.name);
        Destroy(gameObject);  // Destr�i o item da cena
    }
}