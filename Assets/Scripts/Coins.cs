using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coins")
        {
            coin++;
            textCoins.text = "Coins: " + coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
