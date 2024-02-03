using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public GameObject gameOverScreen;
    public GameObject phase2;

    public TextMeshProUGUI levelNumber;

    public AudioSource loseFX;
    public AudioSource bgFX;

    int shipsDestroyed = 0;

    bool level1Over = false;

    public AudioSource bossMusic;

    public int bossHealth = 100;
    public int playerDmg = 5;

    public Slider bossSlider;
    public GameObject healthBar;

    public bool isGamOver = false;
    public bool gameWin = false;

    public GameObject gameWinScreen;
    public AudioSource bossBGM;
    public AudioSource winSFX;
    public GameObject bossPrefab;


    private void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }

        else if (gameController != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bossSlider.minValue = 0;
        bossSlider.maxValue = bossHealth;
        bossSlider.value = bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (shipsDestroyed == 5 && level1Over == false)
        {
            StartCoroutine(DelayStartLevel());
            level1Over = true;
        }

        Debug.Log(bossHealth);

        if(bossHealth <= 0)
        {
            GameWin();
        }


    }

    public void GameWin()
    {
        bossBGM.Stop();
        gameWin = true;
        gameWinScreen.SetActive(true);      
        winSFX.Play();
        Destroy(bossPrefab);
    }

    public void GameOver()
    {
        isGamOver = true;
        bgFX.Stop();
        gameOverScreen.SetActive(true);
        loseFX.Play();

        EnemySpawnerScript.enemySpawner.enabled = false;
        //if (level1Over == true)
        //{
        //    BossSpawnerScript.bossSpawnerScript.enabled = false;
        //    BossControllerScript.bossController.enabled = false;
        //}
        PlayerMovement.playerController.enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShipDestroyed()
    {
        shipsDestroyed++;
    }

    void StartLevel2()
    {
        Debug.Log("LEVEL 2 HAS BEGUN!");
        phase2.SetActive(true);

        EnemySpawnerScript.enemySpawner.enabled = false;
        healthBar.SetActive(true);
        bgFX.Stop();
        bossMusic.Play();
    }

    IEnumerator DelayStartLevel()
    {
        yield return new WaitForSeconds(1);
        levelNumber.text = " ";
        yield return new WaitForSeconds(5);
        levelNumber.text = "Level 2";
        yield return new WaitForSeconds(1);
        StartLevel2();
    }

    public void DecrementBossHealth()
    {
        bossHealth -= playerDmg;
        bossSlider.value = bossHealth;
    }
}
