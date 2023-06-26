using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public int cost;
    public int plantsBought;
    public bool allPlantsBought;
    [SerializeField] private Button button;
    bool[] hasPlantSpawned;
    int buttonIndex;
    GameObject player;
    CoinManager playerCoins;

    [SerializeField] GameObject[] plants;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] List<int> availableSpawnList = new List<int>();

    private void Start()
    {       
        playerCoins = GameObject.Find("GameManager").GetComponent<CoinManager>();
        button = this.GetComponent<Button>();
        hasPlantSpawned = new bool[plants.Length];

        //Creates our List length based amount of plants
        for(int i = 0; i < plants.Length; i++)
        {
            availableSpawnList.Add(i);
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

    public void BuyItem()
    {

        if (playerCoins.coins >= cost)
        {
            playerCoins.coins -= cost;
            BuyPlant(buttonIndex);
            playerCoins.UpdateCanvas();

            Debug.Log("Item bought!");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
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
    
            Instantiate(plants[buttonIndex], spawnPoints[spawnPoint]);
        }
        else
        {
            Debug.Log("All plants bought");
        }

        hasPlantSpawned[buttonIndex] = true; // mark this plant type as spawned

        switch (buttonIndex)
        {
            case 1:
            Debug.Log("Bought from Shop 1");
            cost = NewPrice(cost);
            break;
            case 2:
            Debug.Log("Shop 2");
            break;
            case 3:
            Debug.Log("Shop 3");
            break;
            case 4:
            Debug.Log("Shop 4");
            break;
            case 5:
            Debug.Log("Shop 5");
            break;
        }
    }

    int CreateSpawnNumber()
    {
        /*
        int spawnPointCreated = Random.Range(0, plants.Length);
        int output = availableSpawnList[spawnPointCreated];
        availableSpawnList.RemoveAt(output);
        */

        if (!allPlantsBought)
        {
            int spawnPointIndex = Random.Range(0, availableSpawnList.Count);
            Debug.Log($"spawnlistcount: {plants.Length}");
            int spawnPoint = availableSpawnList[spawnPointIndex];
            Debug.Log($"spawnlistindex: {spawnPointIndex}");
            Debug.Log($"spawnpoint: {spawnPoint}");
            availableSpawnList.RemoveAt(spawnPointIndex);

            plantsBought++;

            if (plantsBought >= plants.Length)
            {
                allPlantsBought = true;
            }

            return spawnPoint;
        }

        return 0;
    }

    int NewPrice(int currentCost)
    {
        float cost = Mathf.Exp(currentCost*1.1f);
        Debug.Log(Mathf.Exp(currentCost*1.1f));
        return (int)cost;
    }
    
}