using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public int cost;
    private Button button;
    public int buttonIndex;
    GameObject player;
    CoinManager playerCoins;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(BuyItem);

        player = GameObject.FindGameObjectWithTag("Player");
        playerCoins = player.GetComponent<CoinManager>();
    }

    private void Update() {
        if(playerCoins.coins >= cost)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

    }

    public void BuyItem()
    {

        if (playerCoins.coins >= cost)
        {
            playerCoins.coins -= cost;
            BuyPlant();
            playerCoins.UpdateCanvas();

            Debug.Log("Item bought!");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    void BuyPlant()
    {
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

    int NewPrice(int currentCost)
    {
        float cost = Mathf.Exp(currentCost*1.1f);
        Debug.Log(Mathf.Exp(currentCost*1.1f));
        return (int)cost;
    } 
    
}