using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;
    private float destroyTimer;
    public float perforate=1;

    private void Start()
    {
        destroyTimer = timeToDestroy;
        perforate += GlobalContador.Instance.levelProjectile;
    }

    private void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<BasicEnemy>().Destroide() ;
            perforate--;
            if (perforate<=0)
            {
                Destroy(gameObject);
            }
           
        }
    }
}
