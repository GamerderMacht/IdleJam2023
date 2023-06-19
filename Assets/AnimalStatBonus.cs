using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStatBonus : MonoBehaviour
{
    TestCoin testCoin;
    public float coinProductionMultiplier;
    public float coinProductionSpeedDecrease;
    
    void Start()
    {
       testCoin = FindObjectOfType<TestCoin>(); 
    }

    
}
