using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStats : MonoBehaviour
{
    [SerializeField] float coinsItGenerates;
    CoinManager coinManager;

    void Start()
    {
        coinManager = FindAnyObjectByType<CoinManager>();
        ApplyPlantCoinBonus();
    }

    void ApplyPlantCoinBonus()
    {
        coinManager.baseCoinGain += coinsItGenerates;
    }
   
    
}
