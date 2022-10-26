using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float Speed = 1;
    [SerializeField] private bool destroy = false;
    private SpriteRenderer spriteRenderer;
    private Color CollisionColor = Color.blue;
    
    void Start()
    {
        player = PlayerMovement.Instance.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            destroy = false;
            spriteRenderer.color = CollisionColor;
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }

}
