using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;  // Refer�ncia ao Box Collider do port�o
    private bool isOpen = false;  // Flag para verificar se o port�o j� foi aberto

    void Start()
    {
        // Obt�m o componente Animator e BoxCollider2D do port�o
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Desativa o Animator no in�cio para impedir que a anima��o ocorra automaticamente
        animator.enabled = false;
    }

    void Update()
    {
        // Verifica se h� objetos com o script ItemInteraction na cena e se o port�o ainda n�o foi aberto
        if (!isOpen)
        {
            ItemInteraction[] itensRestantes = FindObjectsOfType<ItemInteraction>();

            // Se n�o houver mais itens restantes, abre o port�o
            if (itensRestantes.Length == 0)
            {
                AbrirPortao();
            }
        }
    }

    void AbrirPortao()
    {
        // Ativa o Animator para que a anima��o possa ocorrer
        animator.enabled = true;

        // Dispara o trigger para iniciar a anima��o de abertura
        animator.SetTrigger("Abrir");

        // Marca o port�o como aberto
        isOpen = true;

        // Desativa o BoxCollider para permitir a passagem do jogador
        boxCollider.enabled = false;

        Debug.Log("Port�o aberto, anima��o ativada e colisor desativado.");
    }
}

