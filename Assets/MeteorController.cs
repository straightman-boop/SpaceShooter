using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);
        transform.position = position;
    }
}
