using UnityEngine;
using UnityEngine.UI;

public class MutationFarm : MonoBehaviour
{
    public Text coinTxt;
    public double coins;

    public void Start()
    {
        coins = 0;
    }

    public void Update()
    {
        coinTxt.text = "Coins: " + coins;
    }

    public void Click()
    {
        coins += 1;
    }


}

