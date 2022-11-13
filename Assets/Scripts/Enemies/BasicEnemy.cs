using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float Speed = 1;
    public bool destroy = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private Color CollisionColor = Color.blue;
    [SerializeField] private Color CollisionColor2 = Color.blue, CollisionColorTank= Color.blue;
    [SerializeField] private int liveTank=1;
    [SerializeField]bool speed = false, tank=false;
    void Start()
    {
        player = PlayerMovement.Instance.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (speed)
        {
            Speed = 8;
        }
        if (tank) { liveTank = 2; Speed = 2; }
    }
    
    void Update()
    {
        if(!destroy)transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && destroy)
        {
            if (speed) col.gameObject.GetComponent<PlayerMovement>().LevelSpeed(1);
            else if (tank) 
            { 
                GlobalContador.Instance.live++;
                GlobalContador.Instance.Chagelive();
                Debug.Log("tienes mas vida");
                
            }   
            else col.gameObject.GetComponent<PlayerMovement>().levelrign(1);
            Destroy(gameObject);

        }
        else if(col.gameObject.CompareTag("Player") && !destroy)
        {

            GlobalContador.Instance.live --;
            GlobalContador.Instance.Chagelive();
            GlobalContador.Instance.Dead();
            if (speed)
            { 
                GlobalContador.Instance.PassOleada();
                Destroy(gameObject);
            }
        }
    }

    public void Destroide()
    {
        liveTank--;
        if (liveTank == 0) {    
           
            transform.localScale = new Vector2(0.5f, 0.5f);
             destroy = true;
            if (speed) spriteRenderer.color = CollisionColor2;
            else if (tank) { transform.localScale = new Vector2(1f, 1f); spriteRenderer.color = CollisionColorTank; }
            else spriteRenderer.color = CollisionColor;
            GlobalContador.Instance.PassOleada();
            Destroy(gameObject,6);

            }
        

       
    }

}
