using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Para reiniciar a cena

public class MinigameController : MonoBehaviour
{
    public GameObject fallingBallPrefab;
    public Transform spawnLeft;
    public Transform spawnRight;
    public float spawnInterval = 1.0f;
    public TMP_Text countdownText; // Texto de contagem regressiva usando TMP
    public TMP_Text timerText; // Texto de tempo restante usando TMP
    public TMP_Text scoreText; // Texto de pontua��o usando TMP
    public TMP_Text finalScoreText; // Texto final da pontua��o
    public GameObject finalScreen; // Tela final para exibir a pontua��o

    private int score = 0;
    private float gameDuration = 45.0f; // Dura��o do minigame
    private bool isGameActive = false;

    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        int countdown = 5;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1);
            countdown--;
        }

        countdownText.text = "Start!";
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);

        StartCoroutine(StartMinigame());
    }

    IEnumerator StartMinigame()
    {
        isGameActive = true;
        StartCoroutine(SpawnBalls());

        float timer = gameDuration;
        while (timer > 0)
        {
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
            yield return new WaitForSeconds(1);
            timer--;
        }

        EndMinigame();
    }

    IEnumerator SpawnBalls()
    {
        while (isGameActive)
        {
            // Decide aleatoriamente se a bola ser� gerada � esquerda ou � direita
            Transform spawnPosition = Random.value < 0.5f ? spawnLeft : spawnRight;
            Instantiate(fallingBallPrefab, spawnPosition.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    void EndMinigame()
    {
        isGameActive = false;
        finalScreen.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
    }

    // M�todo para reiniciar o jogo
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia a cena atual
    }

    // M�todo para sair do jogo
    public void QuitGame()
    {
        Application.Quit(); // Fecha o jogo (s� funciona em builds, n�o no editor)
    }
}


