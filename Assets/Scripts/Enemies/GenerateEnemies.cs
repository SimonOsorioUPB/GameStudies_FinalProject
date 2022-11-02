using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject [] Enemy;
    public GameObject Player;
    [SerializeField] private float spawnOffset = 40;
    [SerializeField] private float spawnDelay = 5f;
    private float spawnTimer;
    private int Enem�Position;
    private void Start()
    {
        spawnTimer = spawnDelay;
    }

    void Update()
    {
        if (spawnTimer <= 0)
        {
            Enem�Position=Random.Range(0, 2);

            Instantiate(Enemy[Enem�Position], Player.transform.position + new  Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
            spawnTimer = spawnDelay;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
