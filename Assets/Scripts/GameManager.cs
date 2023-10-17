using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int requiredWood = 10; // Quantidade de madeira necess�ria para a vit�ria
    public int totalCollectedWood = 0; // Vari�vel para rastrear a quantidade de madeira coletada
    public GameObject victoryMessage; // Objeto da mensagem de vit�ria
    public static GameManager instance;
    private void Awake() => instance = this;
    private void Start()
    {

        victoryMessage.SetActive(false); // Certifica-se de que a mensagem de vit�ria esteja desativada no in�cio
    }

    // Fun��o para verificar a condi��o de vit�ria
    private void CheckWinCondition()
    {
        if (totalCollectedWood >= requiredWood)
        {
            ActivateVictoryMessage(); // Ative a mensagem de vit�ria
        }
    }

    private void ActivateVictoryMessage()
    {
        if (victoryMessage != null)
        {
            victoryMessage.SetActive(true); // Ativa a mensagem de vit�ria
        }
    }

    // Adicione essa fun��o para notificar o GameManager quando um tronco de madeira � coletado
    public void WoodCollected()
    {
        totalCollectedWood++;
        CheckWinCondition();
    }

}
