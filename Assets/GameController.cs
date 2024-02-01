using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (shipsDestroyed == 5 && level1Over == false)
        {
            StartCoroutine(DelayStartLevel());
            level1Over = true;
        }

        //Debug.Log(shipsDestroyed);
    }

    public void GameOver()
    {
        bgFX.Stop();
        gameOverScreen.SetActive(true);
        loseFX.Play();

        EnemySpawnerScript.enemySpawner.enabled = false;
        BossSpawnerScript.bossSpawnerScript.enabled = false;
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
}
