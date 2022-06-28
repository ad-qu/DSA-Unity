using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerShoot : MonoBehaviour
{
    private bool isShooting;

    public float shootSpeed, shootTimer;

    public Transform shootPos;
    public GameObject bullet;

    string toastText = "Buy this weapon to use it";
    static public bool weapon1, weapon2;

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
        if ((!isShooting) && (weapon1))
        {
            StartCoroutine(Shoot1());
        }
        else if (!weapon1) { onShowToastClicked(); }
    }

    public void Attack2()
    {
        if ((!isShooting) && (weapon2))
        {
            StartCoroutine(Shoot2());
        }
        else if (!weapon2) { onShowToastClicked(); }
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

    public void onShowToastClicked()
    {
#if UNITY_ANDROID
        showAndroidToast();
#else
        Debug.Log("No Toast setup for this platform.");
#endif
    }

    private void showAndroidToast()
    {
        //create a Toast class object
        AndroidJavaClass toastClass =
                    new AndroidJavaClass("android.widget.Toast");

        //create an array and add params to be passed
        object[] toastParams = new object[3];
        AndroidJavaClass unityActivity =
          new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        toastParams[0] =
                     unityActivity.GetStatic<AndroidJavaObject>
                               ("currentActivity");
        toastParams[1] = toastText;
        toastParams[2] = toastClass.GetStatic<int>
                               ("LENGTH_SHORT");

        //call static function of Toast class, makeText
        AndroidJavaObject toastObject =
                        toastClass.CallStatic<AndroidJavaObject>
                                      ("makeText", toastParams);
        //show toast
        toastObject.Call("show");
    }
}
