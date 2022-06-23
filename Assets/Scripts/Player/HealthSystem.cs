using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public static int health = 4;

    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 4) { hearts[0].enabled = true; hearts[1].enabled = true; hearts[2].enabled = true; hearts[3].enabled = true; }
        else if (health == 3) { hearts[0].enabled = false; hearts[1].enabled = true; hearts[2].enabled = true; hearts[3].enabled = true; }
        else if (health == 2) { hearts[0].enabled = false; hearts[1].enabled = false; hearts[2].enabled = true; hearts[3].enabled = true; }
        else if (health == 1) { hearts[0].enabled = false; hearts[1].enabled = false; hearts[2].enabled = false; hearts[3].enabled = true; }
        else { hearts[0].enabled = false; hearts[1].enabled = false; hearts[2].enabled = false; hearts[3].enabled = false; }
    }
}
