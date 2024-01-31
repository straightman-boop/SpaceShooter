using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public GameObject gameOverScreen;

    public AudioSource loseFX;
    public AudioSource bgFX;

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

    }

    public void GameOver()
    {
        bgFX.Stop();
        gameOverScreen.SetActive(true);
        loseFX.Play();

        EnemySpawnerScript.enemySpawner.enabled = false;
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
}
