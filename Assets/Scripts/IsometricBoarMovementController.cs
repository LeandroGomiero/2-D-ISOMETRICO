using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricBoarMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricEnymeRenderer isoRenderer;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricEnymeRenderer>();
    }


    // Update is called once per frame

    Vector2 CalculateMovement()
    {
        // Assumindo que você tem uma referência para o GameObject do jogador.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Obtenha a posição do jogador.
            Vector3 playerPosition = player.transform.position;

            // Calcule a direção para o jogador a partir da posição atual do javali.
            Vector2 directionToPlayer = (playerPosition - transform.position).normalized;

            return directionToPlayer;
        }
        else
        {
            // Se o jogador não for encontrado (por exemplo, se ainda não estiver no jogo),
            // você pode escolher um comportamento alternativo, como parar ou patrulhar.
            return Vector2.zero; // Isso significa que o javali não se moverá.
        }
    }



    void FixedUpdate()
    {
        Vector2 movement = CalculateMovement();
        isoRenderer.SetDirection(movement);

        // Aplicar o movimento ao Rigidbody2D do javali aqui, da mesma forma que estava sendo feito com o jogador.
        Vector2 currentPos = rbody.position;
        Vector2 newPos = currentPos + movement * movementSpeed * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
    }



}