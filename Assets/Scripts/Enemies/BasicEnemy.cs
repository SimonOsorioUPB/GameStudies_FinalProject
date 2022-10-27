using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float Speed = 1;
    public bool destroy = false;
    private SpriteRenderer spriteRenderer;
    private Color CollisionColor = Color.blue;
    
    void Start()
    {
        player = PlayerMovement.Instance.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if(!destroy)transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && destroy)
        {
           
            col.gameObject.GetComponent<PlayerMovement>().levelrign(1);
            Destroy(gameObject);
        }
        else if(col.gameObject.CompareTag("Player") && !destroy)
        {

            GlobalContador.Instance.live --;
            GlobalContador.Instance.Dead();
        }
    }

    public void Destroide()
    {
      
            destroy = true;
            spriteRenderer.color = CollisionColor;
            transform.localScale = new Vector2(0.5f, 0.5f);
            Destroy(gameObject,6);

    }

}
