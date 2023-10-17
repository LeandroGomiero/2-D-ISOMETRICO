using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [SerializeField] public int totalWood;
    public GameManager gameManager; // Arraste o objeto GameManager aqui no Inspector
    public int Totalwood { get => totalWood; set => totalWood = value; }

    int totalCollectedWood = 0; // Vari�vel para rastrear a quantidade de madeira coletada
    public int requiredWood = 10; // Quantidade de madeira necess�ria para a vit�ria



    public int TotalWood
    {
        get { return totalWood; }
    }

   

    // Adicione esta fun��o para notificar o GameManager quando um tronco de madeira � coletado
    public void CollectWood()
    {
        totalWood++;
        totalCollectedWood = TotalWood; // Atualize totalCollectedWood sempre que totalWood for alterado

        if (gameManager != null)
        {
            gameManager.WoodCollected();
        }
    }

}


