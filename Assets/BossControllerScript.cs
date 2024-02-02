using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControllerScript : MonoBehaviour
{
    float speed;

    bool goLeft = true;

    float xPosMin = -2.35f;
    float xPosMax = 2.45f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 position = transform.position;

        if (goLeft)
        {
            GoLeft(position);

            if (position.x < xPosMin)
            {
                goLeft = false;
            }
        }
        else
        {
            GoRight(position);

            if (position.x > xPosMax)
            {
                goLeft = true;
            }
        }




    }

    void GoLeft(Vector2 position)
    {
        position = new Vector2(position.x - speed * Time.deltaTime, position.y);
        transform.position = position;
    }

    void GoRight(Vector2 position)
    {
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;
    }
}
