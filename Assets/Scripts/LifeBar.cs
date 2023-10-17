using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image healthFillImage;
    public Image damageFillImage;
    public Color damageColor = Color.red;
    public float damageScaleFactor = 0.1f;
    private float damageScale = 0.0f;

    private void Start()
    {
        damageFillImage.color = damageColor;
        // Mantém a escala horizontal (eixo X) como 1 (inicialmente visível)
    }

    public void AlteraVida(float vida)
    {
        vida = Mathf.Clamp01(vida);
        damageScale = 1.0f - vida;
        // Atualiza apenas a escala no eixo X (horizontal) e mantém o eixo Y inalterado
        damageFillImage.rectTransform.localScale = new Vector3(1 - damageScale * damageScaleFactor, damageFillImage.rectTransform.localScale.y, 1);
    }
}
