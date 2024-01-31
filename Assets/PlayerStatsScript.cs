using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsScript : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static PlayerStatsScript playerStats;
    int score;

    void Awake()
    {
        if (playerStats == null)
        {
            playerStats = this;
        }

        else if (playerStats != this)
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

    public void UpdateScore()
    {
        score += 100;
        string scoreStr = string.Format("{0.0000000}", score);
        scoreText.text = "Score: " + scoreStr;

    }
}
