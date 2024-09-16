using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Para manipular UI

public class QTEController : MonoBehaviour
{
    public Text promptText;  // Texto que mostra a tecla a ser pressionada
    public Text timerText;  // Texto para o temporizador
    public Text scoreText;  // Texto para a pontua��o
    public float minigameDuration = 60f;  // Dura��o do minigame (1 minuto)

    private float remainingTime;
    private int score = 0;
    private KeyCode currentKey;  // A tecla atual a ser pressionada
    private bool isMinigameActive = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isMinigameActive)
        {
            // Atualiza o temporizador
            remainingTime -= Time.deltaTime;
            timerText.text = "Tempo restante: " + Mathf.Ceil(remainingTime).ToString();

            // Verifica se o jogador pressionou a tecla correta
            if (Input.GetKeyDown(currentKey))
            {
                score += 10;  // Adiciona pontos por acerto
                scoreText.text = "Pontua��o: " + score.ToString();
                GenerateNewPrompt();  // Gera um novo prompt de tecla
            }

            // Verifica se o tempo acabou
            if (remainingTime <= 0f)
            {
                EndMinigame();
            }
        }
    }

    void GenerateNewPrompt()
    {
        // Gera uma tecla aleat�ria entre "A" e "D"
        currentKey = (Random.value > 0.5f) ? KeyCode.A : KeyCode.D;
        promptText.text = "Pressione " + currentKey.ToString() + "!";
    }

    public void StartMinigame()
    {
       

        // Inicia o minigame
        isMinigameActive = true;
        remainingTime = minigameDuration;
        score = 0;

        // Exibe a primeira tecla
        GenerateNewPrompt();
    }

    void EndMinigame()
    {
        isMinigameActive = false;

       
        Debug.Log("Minigame finalizado! Pontua��o final: " + score);
        // Aqui voc� pode adicionar c�digo para retornar � cena anterior ou finalizar o jogo
    }
}
