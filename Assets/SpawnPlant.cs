using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlant : MonoBehaviour
{
   [SerializeField] public GameObject[] spawnPoints;


   [SerializeField] private GameObject[] plants;




   public void SpawnPlantonPoint(int index)
   {
        Instantiate(plants[index], spawnPoints[index].transform.position, Quaternion.identity);
   }
}
