using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BossProjectileScript : MonoBehaviour
{
    public GameObject target;
    float speed = 1f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 position = target.transform.position - transform.position;
            position.Normalize();
            rb.position += position * speed * Time.deltaTime;
        }

        if(GameController.gameController.isGamOver == true)
        {
            Destroy(gameObject);
        }

    }
}
