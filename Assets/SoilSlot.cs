using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSlot : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2f; // Distância mínima para interagir com o slot
    [SerializeField] private Sprite seedsSprite;
    [SerializeField] private Sprite seedlingSprite;
    [SerializeField] private Sprite adultPlantSprite;
    [SerializeField] private Sprite fruitPlantSprite;
    [SerializeField] private float plantingTime = 10f; // Tempo de plantio em segundos

    private Transform playerTransform;
    private SpriteRenderer spriteRenderer;
    private bool isPlanting = false;
    private float currentPlantingTime = 0f;

    private enum PlantingStage { Seeds, Seedling, AdultPlant, FruitPlant }
    private PlantingStage currentStage = PlantingStage.Seeds;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    private void Update()
    {
        if (isPlanting)
        {
            if (currentPlantingTime >= plantingTime)
            {
                currentPlantingTime = 0f;
                AdvancePlantingStage();
            }
            else
            {
                currentPlantingTime += Time.deltaTime;
            }
        }
    }

    private void OnMouseDown()
    {
        if (playerTransform != null)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance <= interactionDistance)
            {
                StartPlanting();
            }
        }
    }

    private void StartPlanting()
    {
        if (!isPlanting)
        {
            isPlanting = true;
        }
    }

    private void AdvancePlantingStage()
    {
        if (currentStage == PlantingStage.FruitPlant)
        {
            // Final do ciclo de plantio
            isPlanting = false;
        }
        else
        {
            currentStage++;
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        switch (currentStage)
        {
            case PlantingStage.Seeds:
                spriteRenderer.sprite = seedsSprite;
                break;
            case PlantingStage.Seedling:
                spriteRenderer.sprite = seedlingSprite;
                break;
            case PlantingStage.AdultPlant:
                spriteRenderer.sprite = adultPlantSprite;
                break;
            case PlantingStage.FruitPlant:
                spriteRenderer.sprite = fruitPlantSprite;
                break;
        }
    }
}
