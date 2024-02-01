using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerController;
    public float speed = 0.1f;

    public GameObject Projectile;
    public GameObject projectilePosition;

    float fireInterval = .25f;
    float nextFire;

    public GameObject Explosion;

    public AudioSource fire;

    public bool isGameOver = false;
    public GameObject RespawnPoint;

    void Awake()
    {
        if (playerController == null)
        {
            playerController = this;
        }

        else if (playerController != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nextFire = fireInterval;
    }

    // Update is called once per frame
    void Update()
    {
        nextFire -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && nextFire <= 0)
        {
            GameObject projectile = (GameObject)Instantiate(Projectile);
            fire.Play();

            projectile.transform.position = projectilePosition.transform.position;
            nextFire = fireInterval;
        }


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - .5f;
        min.x = min.x + .5f;

        max.y = max.y - .5f;
        min.y = min.y + .5f;

        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "enemyProjectile" || collision.tag == "Boss")
        {
            PlayerStatsScript.playerStats.playerLife--;
            Debug.Log("Hit");

            Vector2 expos = transform.position;

            GameObject explosion = (GameObject)Instantiate(Explosion); ;
            explosion.transform.position = expos;


            if (PlayerStatsScript.playerStats.playerLife > 0)
            {
                transform.position = RespawnPoint.transform.position;
            }

            else
            {
                GameController.gameController.GameOver();
                isGameOver = true;
                Destroy(gameObject);
            }
        }
    }


}
