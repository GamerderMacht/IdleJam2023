using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPrices : MonoBehaviour
{
    public TextMeshProUGUI[] priceText;
    public int[] prices;

    
    void Start()
    {
        prices = new int[] {10, 30, 500, 1000, 5000, 10000, 10000};
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShopPriceUI();
    }

    void UpdateShopPriceUI()
    {
          for (int i = 0; i < prices.Length; i++) 
        {
            priceText[i].GetComponent<TextMeshProUGUI>().text = prices[i].ToString() + " Enerlifes";
        }
    }
}
