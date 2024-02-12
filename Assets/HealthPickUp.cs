using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.tag == "Player")
                PickUpHealth();
            
            Destroy(gameObject);
        }
    }

    void PickUpHealth()
    {
        PlayerStatsScript.playerStats.playerLife++;
    }

    void PickUpHealth2()
    {
        Player2Stats.playerStats.playerLife++;
    }
}