using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int enemyHP = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmout)
    {
        enemyHP -= damageAmout;

        if(enemyHP > 0)
        {
            //TAKE DAMAGE
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
