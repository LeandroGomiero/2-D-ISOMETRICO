using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int requiredWood = 10; // Quantidade de madeira necessária para a vitória
    public int totalCollectedWood = 0; // Variável para rastrear a quantidade de madeira coletada
    public GameObject victoryMessage; // Objeto da mensagem de vitória
    public static GameManager instance;
    private void Awake() => instance = this;
    private void Start()
    {

        victoryMessage.SetActive(false); // Certifica-se de que a mensagem de vitória esteja desativada no início
    }

    // Função para verificar a condição de vitória
    private void CheckWinCondition()
    {
        if (totalCollectedWood >= requiredWood)
        {
            ActivateVictoryMessage(); // Ative a mensagem de vitória
        }
    }

    private void ActivateVictoryMessage()
    {
        if (victoryMessage != null)
        {
            victoryMessage.SetActive(true); // Ativa a mensagem de vitória
        }
    }

    // Adicione essa função para notificar o GameManager quando um tronco de madeira é coletado
    public void WoodCollected()
    {
        totalCollectedWood++;
        CheckWinCondition();
    }

}
