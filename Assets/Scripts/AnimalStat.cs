using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStat : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    CoinManager coinManager;
    ShopItemButton shopItemButton;
    public SpriteRenderer mutationSprite;
    int mutationLevel = 1;
    public float multiplierBonus;
    public float afkTimerBonus;
    public float mutationMultiplierBonus;
    public float mutationAfkTimerBonus;

    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
        animalStatBonus = FindObjectOfType<AnimalStatBonus>();
        ApplyAnimalBonus();
    }

    // This is the method to be called on click
    public void OnObjectClick()
    {

        Mutate();
        Debug.Log("Animal GameObject was clicked!");
        
    }

    public void Mutate()
    {
        if (coinManager.mutationCount > 0)
        {   
            coinManager.mutationCount--;
            coinManager.UpdateCanvas();

            switch (mutationLevel) {
                case 1:
                    mutationLevel++;
                    break;
                case 2:
                    mutationLevel++;
                    break;
                case 3:
                    mutationLevel++;
                    break;
                case 4:
                    Debug.Log("Reached maximum mutation level!");
                    break;
            }

            //AnimalGameobjectSprite = NewMutationGameObjectSprite
            //animalStats.ApplyMutationBonus
        }
        else
        {
            Debug.Log("Not enough mutations!");
        }
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
