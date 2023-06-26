using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStat : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    public SpriteRenderer mutationSprite;
    int mutationLevel;
    public float multiplierBonus;
    public float afkTimerBonus;
    public float mutationMultiplierBonus;
    public float mutationAfkTimerBonus;

    void Start()
    {
        animalStatBonus = FindObjectOfType<AnimalStatBonus>();
        ApplyAnimalBonus();
    }

    // This is the method to be called on click
    public void OnObjectClick()
    {
        Debug.Log("GameObject was clicked!");
    }

    void ApplyAnimalBonus()
    {
        animalStatBonus.coinProductionMultiplier += multiplierBonus;
        animalStatBonus.coinProductionSpeedDecrease += afkTimerBonus;
    }

    void ApplyAnimalMutationBonus()
    {
        if (mutationLevel < 3)
        {
            animalStatBonus.coinProductionMultiplier += mutationMultiplierBonus;
            animalStatBonus.coinProductionSpeedDecrease += mutationAfkTimerBonus;
        } else {
            Debug.Log("Reached maximum mutation level!");
        }
    }

}
