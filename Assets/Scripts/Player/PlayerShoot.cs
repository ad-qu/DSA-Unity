using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private bool isShooting;

    public float shootSpeed, shootTimer;

    public Transform shootPos;
    public GameObject bullet;

    private Animator anim;
    void Start()
    {
        isShooting = false;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.J) && !isShooting)
        {
            Attack1();
        }
        else if(Input.GetKey(KeyCode.K) && !isShooting) 
        {
            Attack2();
        }
    }

    public void Attack1()
    {
        if (!isShooting)
        {
            StartCoroutine(Shoot1());
        }
    }

    public void Attack2()
    {
        if (!isShooting)
        {
            StartCoroutine(Shoot2());
        }
    }

    IEnumerator Shoot1()
    {
        int direction()
        {
            if(transform.localScale.x < 0f) { return -1; } else { return +1; }
        }

        isShooting = true;
        BulletDie.weaponType = 1;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        anim.SetTrigger("attack1");
        AudioManager.instance.Play("Shoot");
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    IEnumerator Shoot2()
    {
        int direction()
        {
            if (transform.localScale.x < 0f) { return -1; } else { return +1; }
        }

        isShooting = true;
        BulletDie.weaponType = 2;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        anim.SetTrigger("attack2");
        AudioManager.instance.Play("Shoot");
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
