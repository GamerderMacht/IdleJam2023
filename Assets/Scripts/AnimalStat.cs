using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStat : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    CoinManager coinManager;
    ShopItemButton shopItemButton;
    private SpriteRenderer spriteRenderer;
    public GameObject nextMutation;
    public int mutationLevel = 0;
    public float multiplierBonus;
    public float afkTimerBonus;
    public bool maxMutation;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coinManager = FindObjectOfType<CoinManager>();
        animalStatBonus = FindObjectOfType<AnimalStatBonus>();

        ApplyAnimalBonus();

    }

    // This is the method to be called on click
    public void OnMouseDown()
    {

        Mutate();
        Debug.Log("Animal GameObject was clicked!");
        
    }

    public void Mutate()
    {
        mutationLevel++;
        if (coinManager.mutationCount > 0 && !maxMutation)
        {   
            coinManager.mutationCount--;
            coinManager.UpdateCanvas();
 
            Instantiate(nextMutation, this.transform.position, Quaternion.identity);
            Debug.Log("Mutate worked");
            Destroy(gameObject); 

        }
        else if (maxMutation)
        {
            Debug.Log("Max Mutation");
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


}
