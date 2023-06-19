using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoin : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    public float coins;
    float baseCoinGain = 1;
    public float afkCoinGain = 0;
    public float baseCoinGainDelay = 5;
    public float afkCoinGainDelay = 5;

    void Start()
    {
        animalStatBonus = FindObjectOfType<AnimalStatBonus>();
        StartCoroutine(CoinFarm());
    }
    IEnumerator CoinFarm()
    {
        while (true)
        {
            afkCoinGain = (baseCoinGain * animalStatBonus.coinProductionMultiplier);
            afkCoinGainDelay = (baseCoinGainDelay - animalStatBonus.coinProductionSpeedDecrease);
            coins += afkCoinGain;
            Debug.Log(coins);

            yield return new WaitForSeconds (afkCoinGainDelay);
        }
    }


}
