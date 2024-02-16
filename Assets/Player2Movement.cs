using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public static Player2Movement playerController;
    public float speed;
    float defSpd;

    float x;
    float y;
    Rigidbody2D rb;

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
        rb = GetComponent<Rigidbody2D>();
        x = 0; y = 0;

        defSpd = 3;
        speed = defSpd;
    }

    // Update is called once per frame
    void Update()
    {
        nextFire -= Time.deltaTime;

        if (Input.GetKeyDown("[4]") && nextFire <= 0)
        {
            GameObject projectile = (GameObject)Instantiate(Projectile);
            fire.Play();

            projectile.transform.position = projectilePosition.transform.position;
            nextFire = fireInterval;
        }


        movePlayer();

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);

        if (GameController.gameController.gameWin == true)
        {
            Destroy(gameObject);
        }

        else if (GameController.gameController.isGamOver == true)
        {
            SelfDestruct();
        }
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
        if (collision.tag == "Enemy" || collision.tag == "enemyProjectile" || collision.tag == "Boss" || collision.tag == "Meteors")
        {
            Player2Stats.playerStats.playerLife--;
            Debug.Log("Hit");

            Vector2 expos = transform.position;

            GameObject explosion = (GameObject)Instantiate(Explosion); ;
            explosion.transform.position = expos;


            if (Player2Stats.playerStats.playerLife > 0)
            {
                transform.position = RespawnPoint.transform.position;
            }

            else
            {
                GameController.gameController.shipsNum--;
                isGameOver = true;
                Destroy(gameObject);
            }
        }
    }

    void SelfDestruct()
    {
        Vector2 expos = transform.position;

        GameObject explosion = (GameObject)Instantiate(Explosion); ;
        explosion.transform.position = expos;

        Destroy(gameObject);
    }

    void movePlayer()
    {
        rb.velocity = new Vector2(x * speed * Time.deltaTime, y *
        speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = 10.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -10.0f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y = -10.0f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 10.0f;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            y = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) ||
        Input.GetKeyUp(KeyCode.RightArrow))
        {
            x = 0;
        }
    }
}
