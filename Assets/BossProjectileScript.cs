using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BossProjectileScript : MonoBehaviour
{
    public GameObject target;
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { //REVISIT ELDEN BYTES

        Vector2 position = target.transform.position - transform.position;
        position.Normalize();
        transform.position += target.transform.position * speed * Time.deltaTime;

    }
}
