using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPrices : MonoBehaviour
{
    public TextMeshPro[] priceText;
    public int[] prices;

    
    void Start()
    {
        prices = new int[] {10, 50, 100, 200, 500, 1000, 10000};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
