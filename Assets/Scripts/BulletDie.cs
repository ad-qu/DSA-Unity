using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    static public int weaponType;
    public GameObject dieEffect;
    public float dieTime;
    private void Start()
    {
        StartCoroutine(Timer());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Enemy")
        {
            if(weaponType == 1)
            {
                collisionGameObject.GetComponent<EnemyHP>().TakeDamage(1);
            }
            else
            {
                collisionGameObject.GetComponent<EnemyHP>().TakeDamage(2);
            }
            Die();
        }

        else if(collisionGameObject.name != "Player")
        {
            Die();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
    }

    public void Die()
    {
        if(dieEffect != null)
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
