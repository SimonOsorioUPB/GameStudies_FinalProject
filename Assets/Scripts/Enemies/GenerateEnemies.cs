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
            switch (GlobalContador.Instance.Oleada+1)
            {
                case 1:
                   Debug.Log("los enemigos basico ");
                    Instantiate(Enemy[0], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                    break;
                case 2:
                    EnemīPosition = Random.Range(0,2);
                    Instantiate(Enemy[EnemīPosition], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                    Debug.Log("velocitos y normales  ");
                    break;
                case 3:
                    EnemīPosition = Random.Range(0, 3);
                    Instantiate(Enemy[EnemīPosition], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                    Debug.Log("velocitos y normales  ");
                    Debug.Log("vida y los demas   ");
                    break;
                case 5:
                    Debug.Log("jefe  ");
                    break;
                default:
                    Debug.Log("otro  ");
                    EnemīPosition = Random.Range(0, 3);
                    Instantiate(Enemy[EnemīPosition], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                    Debug.Log("velocitos y normales  ");
                    Debug.Log("vida y los demas   ");
                    break;

            }
            spawnTimer = spawnDelay;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
