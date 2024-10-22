using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;  // Referência ao Box Collider do portão
    private bool isOpen = false;  // Flag para verificar se o portão já foi aberto

    void Start()
    {
        // Obtém o componente Animator e BoxCollider2D do portão
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Desativa o Animator no início para impedir que a animação ocorra automaticamente
        animator.enabled = false;
    }

    void Update()
    {
        // Verifica se há objetos com o script ItemInteraction na cena e se o portão ainda não foi aberto
        if (!isOpen)
        {
            ItemInteraction[] itensRestantes = FindObjectsOfType<ItemInteraction>();

            // Se não houver mais itens restantes, abre o portão
            if (itensRestantes.Length == 0)
            {
                AbrirPortao();
            }
        }
    }

    void AbrirPortao()
    {
        // Ativa o Animator para que a animação possa ocorrer
        animator.enabled = true;

        // Dispara o trigger para iniciar a animação de abertura
        animator.SetTrigger("Abrir");

        // Marca o portão como aberto
        isOpen = true;

        // Desativa o BoxCollider para permitir a passagem do jogador
        boxCollider.enabled = false;

        Debug.Log("Portão aberto, animação ativada e colisor desativado.");
    }
}

