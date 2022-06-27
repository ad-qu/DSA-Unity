using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int enemyHP = 4;

    public void TakeDamage(int damageAmout)
    {
        enemyHP -= damageAmout;

        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
