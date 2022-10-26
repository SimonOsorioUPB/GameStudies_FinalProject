using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShot : MonoBehaviour
{
    [SerializeField] private int projectileAmount;
    [SerializeField] private GameObject projectilePrefab;

    private Vector2 startingPoint;

    [SerializeField] private float moveSpeed = 5f, radius = 5f;

    [SerializeField] private float attackDelay = 1f;
    private float attackTimer;

    private void Start()
    {
        attackTimer = attackDelay;
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            SpawnProjectiles(projectileAmount);
            attackTimer = attackDelay;
        }
    }

    private void SpawnProjectiles(int projectileAmount)
    {
        float angleStep = 360f / projectileAmount;
        float angle = 0f;

        startingPoint = transform.position;
        
        for (int i = 0; i <= projectileAmount - 1; i++)
        {
            float projectileXDirection = startingPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileYDirection = startingPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileXDirection, projectileYDirection);
            Vector2 projectileMoveDirection = (projectileVector - startingPoint).normalized * moveSpeed;

            GameObject projectile = Instantiate(projectilePrefab, startingPoint, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }

}
