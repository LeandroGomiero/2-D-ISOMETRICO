using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private float interactionDistance = 2f; // Dist�ncia m�nima para interagir com a �rvore
    [SerializeField] private GameObject woodPrafab;

    [SerializeField] private ParticleSystem leafs;


    private bool isDestroyed = false;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void OnHit()
    {
        if (isDestroyed)
            return;

        treeHealth--;
        anim.SetTrigger("isHit");
        leafs.Play();

        if (treeHealth <= 0)
        {
            // Cria o tronco e inicia os drops de madeira
            Instantiate(woodPrafab, transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0f), transform.rotation);
            anim.SetTrigger("cut");
            isDestroyed = true;
        }
    }

    private void OnMouseDown()
    {
        if (!isDestroyed && playerTransform != null)
        {
            // Calcula a dist�ncia entre a �rvore e o jogador
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            // Verifica se o jogador est� dentro da dist�ncia m�nima
            if (distance <= interactionDistance)
            {
                OnHit();
            }
        }
    }
}

