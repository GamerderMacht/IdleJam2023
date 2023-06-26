using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CoinManager : MonoBehaviour
{
    AnimalStatBonus animalStatBonus;
    public static CoinManager instance = null;
    public int mutationCount = 0;
    public float coins;
    public float baseCoinGain = 1;
    public float afkCoinGain = 0;
    public float baseCoinGainDelay = 5;
    public float afkCoinGainDelay = 5;
    public TextMeshProUGUI coinTxt;
    [SerializeField] TextMeshProUGUI mutationText;

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
        coinTxt.text = "0";
        mutationText.text = "0";
        //finds the gameobject text component if not assigned in inspector
        //if(coinTxt == null) GameObject.FindWithTag("CoinNumber").GetComponent<TextMeshPro>();
        StartCoroutine(CoinFarm());
    }
    void Update()
    {
        UpdateCanvas();
    }
    public void Click() //Handles the player receiving coins by clicking on plants
    {
        coins += 100000;
        //coinTxt.text = coins.ToString();
    }
    IEnumerator CoinFarm() //handles the coins the player gets over time
    {
        while (true)
        {
            afkCoinGain = (baseCoinGain * animalStatBonus.coinProductionMultiplier);
            afkCoinGainDelay = (baseCoinGainDelay - animalStatBonus.coinProductionSpeedDecrease);
            coins += afkCoinGain;
            UpdateCanvas();
            // Debug.Log(coins);

            yield return new WaitForSeconds (afkCoinGainDelay);
        }
    }

    public void UpdateCanvas()
    {
        coinTxt.text = coins.ToString();
       //mutationText.text = mutationPoints.ToString();
    }
}
