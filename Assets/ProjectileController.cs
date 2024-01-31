using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    float speed;
    public GameObject Explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            PlayerStatsScript.playerStats.UpdateScore();
        }


        if (collision.tag == "Enemy" || collision.tag == "enemyProjectile")
        {
            Vector2 expos = transform.position;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            GameObject explosion = (GameObject)Instantiate(Explosion); ;
            explosion.transform.position = expos;

        }

    }
}
