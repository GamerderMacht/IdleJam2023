using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStatBonus : MonoBehaviour
{
    CoinManager coinManager;
    public float coinProductionMultiplier = 1;
    public float coinProductionSpeedDecrease;
    public float coinBonusMultiplier = 1;
    public float cooldown = 30f;
    private float elapsedTime = 0f;
    public bool bonusReady = false;
    
    void Start()
    {
       coinManager = FindObjectOfType<CoinManager>(); 
    }
    void Update()
    {
        BonusCoinsCooldown();
    }

    void BonusCoinsCooldown()
    {
        elapsedTime += Time.deltaTime; // Track the time passed

        if (elapsedTime >= cooldown)
        {
            bonusReady = true; 
            elapsedTime = 0f;
            Debug.Log(bonusReady); 
        }

        if (bonusReady)
        {
            coinManager.bonusCoinsMultiplier = coinBonusMultiplier;
            bonusReady = false;
        }
    }
    

    
}
