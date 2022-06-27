using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private int currentLevel = 1;
    private int nextLevel = 2;

    public GameObject[] players;
    public GameObject[] fallDetectors;
    public GameObject[] infoMenuScreens;
    public GameObject[] pauseMenuScreens;
    public GameObject[] endMenuScreens;

    static public bool activeShield = false;

    public TextMeshProUGUI levelText;

    public TextMeshProUGUI coinEnd;
    public TextMeshProUGUI pointsEnd;

    public GameObject infoMenuScreen;
    public GameObject pauseMenuScreen;
    public GameObject endMenuScreen;

    private void Start()
    {
        respawnPoint = transform.position;

        endMenuScreen.SetActive(false);

        StartCoroutine(ShowMessage());
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
            if (nextLevel == 2) 
            { 
                GameManager.level = 2; currentLevel = 2 ; nextLevel = 3; 
                
                transform.position = respawnPoint;

                SceneManager.LoadScene(currentLevel);
                GameManager.InitGame();
            }
            else if (nextLevel == 3) 
            { 
                GameManager.level = 1; currentLevel = 1; nextLevel = 2;

                transform.position = respawnPoint;

                End();
            }

            StartCoroutine(ShowMessage());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            AudioManager.instance.Play("Hit");

            if (activeShield)
            {
                HealthSystem.health = HealthSystem.health - 1;
            }
            else 
            { 
                HealthSystem.health = HealthSystem.health - 2; 
            }
            
            if(HealthSystem.health <= 0)
            {
                HealthSystem.health = 4;
                transform.position = respawnPoint;
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    public void End()
    {
        Time.timeScale = 0;
        infoMenuScreen.SetActive(false);
        endMenuScreen.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        endMenuScreen.SetActive(false);

        HealthSystem.health = 4;

        SceneManager.LoadScene("Level1");
        GameManager.InitGame();

        infoMenuScreen.SetActive(true);
    }

    private void OnLevelWasLoaded(int level)
    {
        transform.position = respawnPoint;

        players = GameObject.FindGameObjectsWithTag("Player");
        fallDetectors = GameObject.FindGameObjectsWithTag("FallDetector");
        infoMenuScreens = GameObject.FindGameObjectsWithTag("GameInformationPanel");
        pauseMenuScreens = GameObject.FindGameObjectsWithTag("PauseMenuPanel");
        endMenuScreens = GameObject.FindGameObjectsWithTag("FinishMenuPanel");

        for (int i = 1; players.Length > i; i++)
        {
            Destroy(players[i]);
        }

        for (int i = 1; fallDetectors.Length > i; i++)
        {
            Destroy(fallDetectors[i]);
        }

        for (int i = 1; infoMenuScreens.Length > i; i++)
        {
            Destroy(infoMenuScreens[i]);
        }

        for (int i = 1; pauseMenuScreens.Length > i; i++)
        {
            Destroy(pauseMenuScreens[i]);
        }

        for (int i = 1; endMenuScreens.Length > i; i++)
        {
            Destroy(endMenuScreens[i]);
        }

        pauseMenuScreen.SetActive(false);
        endMenuScreen.SetActive(false);
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
