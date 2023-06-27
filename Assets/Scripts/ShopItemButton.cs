using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public int cost;

    [SerializeField] private Button button;
    
    int buttonIndex;
    GameObject player;
    CoinManager coinManager;
    ShopPrices shopPrices;
    AnimalStat animalStat;

    bool[] hasPlantSpawned;
    
    public int plantsBought;
    public bool allPlantsBought;
    [SerializeField] GameObject[] plants;
    [SerializeField] Transform[] plantSpawnPoints;
    [SerializeField] List<int> availablePlantSpawnList = new List<int>();
    
    [SerializeField] GameObject[] animals;
    [SerializeField] Transform[] animalSpawnPoints;

    private void Start()
    {      
        shopPrices = FindObjectOfType<ShopPrices>();
        cost = shopPrices.prices[buttonIndex];
        coinManager = FindObjectOfType<CoinManager>();
        animalStat = FindObjectOfType<AnimalStat>();
        button = this.GetComponent<Button>();
        hasPlantSpawned = new bool[plants.Length];

        //Creates our List length based amount of plants
        for(int i = 0; i < plants.Length; i++)
        {
            availablePlantSpawnList.Add(i);
        }
        
    }

    private void Update() {

        if(this.gameObject.tag != "Player")
        {
            if(coinManager.coins >= cost)
            {

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }   
        

    }

    public void BuyItem(int buttonIndex)
    {
        Debug.Log("buttonindex clicked with is " + buttonIndex);
        if (coinManager.coins >= shopPrices.prices[buttonIndex])
        {
            coinManager.coins = Mathf.RoundToInt(coinManager.coins - shopPrices.prices[buttonIndex]);
            coinManager.UpdateCanvas();

            switch (buttonIndex)
            {
                case 0: case 1: case 2: case 3: case 4: case 5:
                    Debug.Log("Bought from Plant " + buttonIndex);
                    BuyPlant(buttonIndex);
                    cost = NewPrice(shopPrices.prices[buttonIndex]);
                    shopPrices.prices[buttonIndex] = cost;
                    Debug.Log("New price is " + cost);
                    break;
                
                case 6:
                    Debug.Log("Bought from Mutation");
                    BuyMutation();
                    cost = NewPrice(shopPrices.prices[buttonIndex]);
                    shopPrices.prices[buttonIndex] = cost;
                    Debug.Log("New price is " + cost);
                    break;
            }

            Debug.Log("Item bought!");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }

    }

    public void BuyMutation()
    {
        coinManager.mutationCount++;
    }

    public void BuyPlant(int buttonIndex)
    {

        if (hasPlantSpawned[buttonIndex])
        {
            Debug.Log("This plant has already been spawned!");
            return;
        }
        
        if (!allPlantsBought)
        {
            //generate a random spawnplace
            int spawnPoint = CreateSpawnNumber();

            //place the plant on a random place
           
            Instantiate(plants[buttonIndex], plantSpawnPoints[spawnPoint].transform.position, Quaternion.identity);

            SpawnAnimal();
        }
        else
        {
            Debug.Log("All plants bought");
        }

        hasPlantSpawned[buttonIndex] = true; // mark this plant type as spawned
    }

    int CreateSpawnNumber()
    {
        int spawnPointIndex = Random.Range(0, availablePlantSpawnList.Count);
        int spawnPoint = availablePlantSpawnList[spawnPointIndex];
        availablePlantSpawnList.RemoveAt(spawnPointIndex);

        // Debug.Log($"spawnlistcount: {plants.Length}");
        // Debug.Log($"spawnlistindex: {spawnPointIndex}");
        // Debug.Log($"spawnpoint: {spawnPoint}");

        plantsBought++;

        if (plantsBought >= plants.Length)
        {
            allPlantsBought = true;
        }

        return spawnPoint;
    }

    int NewPrice(int currentCost)
    {
        float newCost = currentCost * 1.1f;
        Debug.Log(newCost);
        return Mathf.RoundToInt(newCost);
    }

    void SpawnAnimal()
    {
        if (plantsBought == 3)
        {
            Instantiate(animals[0], animalSpawnPoints[0].transform.position, Quaternion.identity);
        }

        if (plantsBought == 6)
        {
            Instantiate(animals[1], animalSpawnPoints[1].transform.position, Quaternion.identity);
        }
    }
}