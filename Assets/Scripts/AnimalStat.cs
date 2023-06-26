using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStat : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    public SpriteRenderer mutationSprite;
    bool mutation;
    public float multiplierBonus;
    public float afkTimerBonus;
    public float mutationMultiplierBonus;
    public float mutationAfkTimerBonus;
    void Start()
    {
        animalStatBonus = FindObjectOfType<AnimalStatBonus>();
        ApplyAnimalBonus();
    }

    void ApplyAnimalBonus()
    {
        animalStatBonus.coinProductionMultiplier += multiplierBonus;
        animalStatBonus.coinProductionSpeedDecrease += afkTimerBonus;
    }

    void ApplyAnimalMutationBonus()
    {
        if (mutation)
        {
            animalStatBonus.coinProductionMultiplier += mutationMultiplierBonus;
            animalStatBonus.coinProductionSpeedDecrease += mutationAfkTimerBonus;
        }
    }

}
