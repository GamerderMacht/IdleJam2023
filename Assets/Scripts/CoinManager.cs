using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    public static CoinManager instance = null;
    public float coins;
    public float baseCoinGain = 1;
    public float afkCoinGain = 0;
    public float baseCoinGainDelay = 5;
    public float afkCoinGainDelay = 5;
    public Text coinTxt;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        animalStatBonus = FindObjectOfType<AnimalStatBonus>();
        StartCoroutine(CoinFarm());
    }
    void Update()
    {
        //Just commented it to avoid errors while playtesting, feel free to uncomment once you add the text back to the scene
        //coinTxt.text = "Coins: " + coins;
    }
    public void Click() //Handles the player receiving coins by clicking on plants
    {
        coins += 1;
    }
    IEnumerator CoinFarm() //handles the coins the player gets over time
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
