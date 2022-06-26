using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coins")
        {
            AudioManager.instance.Play("Coin");

            coin++;
            textCoins.text = coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
