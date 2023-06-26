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
    CoinManager playerCoins;

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
        playerCoins = GameObject.Find("GameManager").GetComponent<CoinManager>();
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
            if(playerCoins.coins >= cost)
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

        if (playerCoins.coins >= cost)
        {
            playerCoins.coins -= cost;
            playerCoins.UpdateCanvas();

            switch (buttonIndex)
            {
                case 0:
                Debug.Log("Bought from Plant 1");
                BuyPlant(buttonIndex);
                cost = NewPrice(cost);
                break;
                case 1:
                Debug.Log("Bought from Plant 2");
                BuyPlant(buttonIndex);
                cost = NewPrice(cost);
                break;
                case 2:
                Debug.Log("Bought from Plant 3");
                BuyPlant(buttonIndex);
                cost = NewPrice(cost);
                break;
                case 3:
                Debug.Log("Bought from Plant 4");
                BuyPlant(buttonIndex);
                cost = NewPrice(cost);
                break;
                case 4:
                Debug.Log("Bought from Plant 5");
                BuyPlant(buttonIndex);
                cost = NewPrice(cost);
                break;
                case 5:
                Debug.Log("Bought from Plant 6");
                BuyPlant(buttonIndex);
                cost = NewPrice(cost);
                break;
                case 6:
                Debug.Log("Bought from Mutation");
                BuyMutation(buttonIndex);
                cost = NewPrice(cost);
                break;
            }

            Debug.Log("Item bought!");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }

    }

    public void BuyMutation(int buttonIndex)
    {
        
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
    
            Instantiate(plants[buttonIndex], plantSpawnPoints[spawnPoint]);

            // SpawnAnimal();
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
        float cost = Mathf.Exp(currentCost*1.1f);
        Debug.Log(Mathf.Exp(currentCost*1.1f));
        return (int)cost;
    }

    void SpawnAnimal()
    {
        if (plantsBought == 3)
        {
            Instantiate(animals[0], animalSpawnPoints[0]);
        }

        if (plantsBought == 6)
        {
            Instantiate(animals[1], animalSpawnPoints[1]);
        }
    }
    
}