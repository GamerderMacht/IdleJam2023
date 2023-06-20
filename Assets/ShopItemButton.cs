using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public int cost;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(BuyItem);
    }

    public void BuyItem()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CoinManager playerCoins = player.GetComponent<CoinManager>();

        if (playerCoins.coins >= cost)
        {
            playerCoins.coins -= cost;
            Debug.Log("Item bought!");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}