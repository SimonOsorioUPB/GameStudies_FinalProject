using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHelp : MonoBehaviour
{
    [SerializeField]private GameObject Enemy;
    [SerializeField] private float Speed = 1;
    public bool destroy = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int liveTank = 1;
    [SerializeField] bool speed = false, tank = false;
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("invoke");
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (speed)
        {
            Speed = 8;
        }
        if (tank) { liveTank = 2; Speed = 2; }
    }

    void Update()
    {
        
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (Enemy == null)
            {
                Enemy = GameObject.FindGameObjectWithTag("invoke");
            }
            
        }
        else
        {
            if (!destroy) transform.position = Vector2.MoveTowards(transform.position, Enemy.transform.position, Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (col.gameObject.GetComponent<BasicEnemy>().liveTank<=0)
            {
                Destroy(col.gameObject);
            }
            else
            {
                col.gameObject.GetComponent<BasicEnemy>().Destroide();
                Destroy(gameObject);
            }
         
           
            

        }
        else if (col.gameObject.CompareTag("invoke"))
        {
            col.gameObject.GetComponent<InvokeEnemy>().Destroide();
            
       
             Destroy(gameObject);
            
        }
    }
}
