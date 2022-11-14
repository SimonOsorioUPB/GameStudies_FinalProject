using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasicEnemy : MonoBehaviour
{
    private GameObject player;
    public Slider mainSlider;
    [SerializeField] private float Speed = 1;
    public bool destroy = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject slimeDead;
    [SerializeField] public int liveTank=1;
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
        mainSlider.maxValue = liveTank;
        mainSlider.value = liveTank;
    }
    
    void Update()
    {
        if(!destroy)transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
        mainSlider.value = liveTank;
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.gameObject.CompareTag("Player") && !destroy)
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
           
         
             destroy = true;
             GameObject projectile = Instantiate(slimeDead, transform.position, Quaternion.identity);
         
            GlobalContador.Instance.PassOleada();
            Destroy(gameObject);

            }
        

       
    }

}
