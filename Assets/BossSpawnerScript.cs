using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerScript : MonoBehaviour
{
    public static BossSpawnerScript bossSpawnerScript;
    //public GameObject bossShipPrefab;
    public GameObject meteorsPrefab;

    public float xMetMax = 3.8f;
    public float xMetMin = 3.8f;
    public float yMetMax = 4.45f;
    public float yMetMin = -4.45f;

    float spawnInterval;

    private void Awake()
    {
        if (bossSpawnerScript == null)
        {
            bossSpawnerScript = this;
        }

        else if(bossSpawnerScript != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0)
        {
            float spawnXPosition = Random.Range(xMetMin, xMetMax);
            float spawnYPostion = Random.Range(yMetMin, yMetMax);

            GameObject enemyShip = (GameObject)Instantiate(meteorsPrefab);

            enemyShip.transform.position = new Vector2(spawnXPosition, spawnYPostion);

            spawnInterval = Random.Range(1, 3);
        }
    }
}
