using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStat : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    bool mutation;
    public float addToMultiplierBonus;
    public float addToAfkTimerBonus;
    public float addToBonus;
    public float mutationAddToMultiplierBonus;
    public float mutationAddToAfkTimerBonus;
    public float mutationAddToBonus;
    void Start()
    {
        animalStatBonus = FindObjectOfType<AnimalStatBonus>();
        ApplyAnimalBonus();
    }

    void ApplyAnimalBonus()
    {
        animalStatBonus.coinProductionMultiplier += addToMultiplierBonus;
        animalStatBonus.coinProductionSpeedDecrease += addToAfkTimerBonus;
        animalStatBonus.coinBonusMultiplier += addToBonus;
    }

    void ApplyAnimalMutationBonus()
    {
        if (mutation)
        {
            animalStatBonus.coinProductionMultiplier += mutationAddToMultiplierBonus;
            animalStatBonus.coinProductionSpeedDecrease += mutationAddToAfkTimerBonus;
            animalStatBonus.coinBonusMultiplier += mutationAddToBonus;
        }
    }

}
