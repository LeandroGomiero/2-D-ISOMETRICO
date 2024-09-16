using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public KeyCode targetKey;  // A tecla que a gota corresponde

    void Update()
    {
        // Move a gota para baixo
        transform.Translate(Vector3.down * Time.deltaTime * 5f);  // Ajuste a velocidade conforme necessário

        // Verifica se a gota saiu da tela
        if (transform.position.y < -6f)  // Ajuste conforme necessário
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(KeyCode key)
    {
        targetKey = key;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bucket"))
        {
            // A gota foi coletada corretamente
            Destroy(gameObject);
        }
    }
}
