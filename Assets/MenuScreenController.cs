using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public static MenuScreenController menuScreenController;

    private void Awake()
    {
        if (menuScreenController == null)
        {
            menuScreenController = this;
        }

        else if (menuScreenController != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
