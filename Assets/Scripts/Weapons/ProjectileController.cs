using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;
    private float destroyTimer;

    private void Start()
    {
        destroyTimer = timeToDestroy;
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
            Destroy(col.gameObject);
        }
    }
}
