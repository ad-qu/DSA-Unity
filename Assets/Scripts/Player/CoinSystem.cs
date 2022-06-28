using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    static public float coin;

    public TextMeshProUGUI infoCoins, endCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coins")
        {
            AudioManager.instance.Play("Coin");

            coin++;
            infoCoins.text = coin.ToString();
            endCoins.text = coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
