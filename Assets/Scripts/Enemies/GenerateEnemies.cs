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
    private int EnemīPosition;
    private void Start()
    {
        spawnTimer = spawnDelay;
    }

    void Update()
    {
        if (spawnTimer <= 0)
        {
            EnemīPosition=Random.Range(0, 2);

            Instantiate(Enemy[EnemīPosition], Player.transform.position + new  Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
            spawnTimer = spawnDelay;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
