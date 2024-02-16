using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    SpriteRenderer sprite;
    PolygonCollider2D box;

    public float speedPowerUp = 6f;
    public float speedDuration = 6f;
    float speedCooldown;
    public bool speedOn;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (speedOn == true)
        {
            speedCooldown -= Time.deltaTime;
            if (speedCooldown <= 0)
            {
                speedOn = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.name == "Player1")
            {
                IncreaseSpeed("Player1");
            }

            else if (collision.name == "Player2")
            {
                IncreaseSpeed("Player2");
            }

            //Destroy(gameObject);
        }

        sprite.enabled = false;
        box.enabled = false;
    }

    public void IncreaseSpeed(string player)
    {
        if (player == "Player1")
        {
            PlayerMovement.playerController.speed = speedPowerUp;
            speedOn = true;
            speedDuration = speedCooldown;
        }

        if (player == "Player2")
        {
            Player2Movement.playerController.speed = speedPowerUp;
            speedOn = true;
            speedDuration = speedCooldown;
        }
    }


}
