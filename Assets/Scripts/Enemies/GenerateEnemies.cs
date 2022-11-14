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
    [SerializeField] private float spawnDelay = 6f;
    [SerializeField] private float spawnTimer;
    private int Enem�Position;
    bool kindslimeDead = false;
    private void Start()
    {
        spawnTimer = spawnDelay;
    }

    void Update()
    {
        if (spawnTimer <= 0)
        {
            if (kindslimeDead)
            {
                if (GlobalContador.Instance.DeadKind)
                {
                    kindslimeDead = false;
                   
                }
            }
            else
            {
                switch (GlobalContador.Instance.Oleada+1)
                {
                    case 1:
                       Debug.Log("ronda 1 los enemigos basico ");
                        Instantiate(Enemy[0], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                        break;
                    case 2:
                        Enem�Position = Random.Range(0,2);
                        Instantiate(Enemy[Enem�Position], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                        Debug.Log(" ronda 2 velocitos y normales  ");
                        break;
                    case 3:
                        Enem�Position = Random.Range(0, 3);
                        Instantiate(Enemy[Enem�Position], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                        Debug.Log("ronda 3 velocitos , normales, tanques  ");
                        Debug.Log("vida y los demas   ");
                        break;
                    case 4:
                        Enem�Position = Random.Range(0, 3);
                        Instantiate(Enemy[Enem�Position], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                        Debug.Log("Ronda 4 ");
         
                        break;
                    case 5:
                        Debug.Log("primer invokador   ");
                        Instantiate(Enemy[3], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                        break;
                    case 9:
                        Debug.Log("Rey slime   ");
                 
                        Instantiate(Enemy[4], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                        spawnTimer = spawnDelay;
                        kindslimeDead = true;
                        break;
                    default:
                        Debug.Log("otro  ");
                        Enem�Position = Random.Range(0, 4);
                        Instantiate(Enemy[Enem�Position], Player.transform.position + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset)), transform.rotation);
                        Debug.Log("velocitos y normales  ");
                        Debug.Log("vida y los demas   ");
                        break;

                }
            }
            spawnTimer = spawnDelay - GlobalContador.Instance.Oleada*0.1f;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
