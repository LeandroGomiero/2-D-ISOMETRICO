using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string nomeProximoPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IrLocal();
    }
    private void IrLocal()
    {
        SceneManager.LoadScene(this.nomeProximoPortal);
    }
}
