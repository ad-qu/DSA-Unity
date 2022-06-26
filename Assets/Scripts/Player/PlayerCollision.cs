using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private string currentLevel;
    private string nextLevel;

    static public bool activeShield = false;

    public TextMeshProUGUI levelText;


    private void Start()
    {
        respawnPoint = transform.position;

        StartCoroutine(ShowMessage());

        currentLevel = GameManager.level.ToString();

        if(currentLevel == "1") { nextLevel = "Level2"; }
        else if (currentLevel == "2") { nextLevel = "Level3"; }
        else if (currentLevel == "3") { nextLevel = "TheEnd"; }
    }

    private void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            HealthSystem.health = 4;
        }
        else if (collision.transform.tag == "Finish")
        {
            if (nextLevel == "Level2") { GameManager.level = 2; currentLevel = "Level2" ; nextLevel = "Level3"; }
            else if (nextLevel == "Level3") { GameManager.level = 3; currentLevel = "Level3"; nextLevel = "TheEnd"; }

            SceneManager.LoadScene(currentLevel);
            GameManager.InitGame();

            if (nextLevel == "Level2") { currentLevel = "Level2"; nextLevel = "Level3"; }
            else if (nextLevel == "Level3") { currentLevel = "Level3"; nextLevel = "TheEnd"; }

            StartCoroutine(ShowMessage());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            if(activeShield)
            {
                HealthSystem.health = HealthSystem.health - 1;

            }
            else 
            { 
                HealthSystem.health = HealthSystem.health - 2; 
            }
            
            if(HealthSystem.health <= 0)
            {
                transform.position = respawnPoint;
                HealthSystem.health = 4;
            }

            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 10);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7, 10, false);
    }
    IEnumerator ShowMessage()
    {
        levelText.text = "LEVEL " + GameManager.level;
        levelText.enabled = true;
        yield return new WaitForSeconds(2);
        levelText.enabled = false;
    }
}
