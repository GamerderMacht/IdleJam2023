using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStatBonus : MonoBehaviour
{
    CoinManager coinManager;
    public float coinProductionMultiplier = 1;
    public float coinProductionSpeedDecrease;
    
    void Start()
    {
       coinManager = FindObjectOfType<CoinManager>(); 
    }

    
}
