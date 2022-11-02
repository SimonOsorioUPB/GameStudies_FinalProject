using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    private Rigidbody2D rb;
    private Vector3 movement;
  
    [SerializeField] private float speed = 2f;
    [SerializeField] private int nextLevel=10;
    public int puntaje =0;
    public int Speddpoints= 0;
    public int LevelSpeedi=0;
    [SerializeField]private int  big=1;
    
    private Animator animator;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector3();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        rb.velocity = movement * speed;
    }

    public void levelrign(int level)
    {
        puntaje += level;
        if (puntaje>= nextLevel)
        {

            Debug.Log("se volvio mas grande el slime, ahora tiene mas hambre ");
            transform.localScale=new Vector3(1+(big*0.3f),1+ (big * 0.3f), 1+ (big * 0.3f));
            big++;
            nextLevel = puntaje * 2;
            GlobalContador.Instance.levelPlayer++;
            GlobalContador.Instance.levelProjectile++;
        }
    }
    internal void LevelSpeed(int level)
    {
        Speddpoints += level;
        if (Speddpoints >= nextLevel)
        {

            Debug.Log("se volvio mas rapido ");
            speed += 2;
            LevelSpeedi++;
            nextLevel = Speddpoints * 2;
            GlobalContador.Instance.levelSpeed++;
           
        }
    }
    internal void levenDown()
    { 
        big--;
        transform.localScale = new Vector3(1 - (big * 0.3f), 1 -+ (big * 0.3f), 1 - (big * 0.3f));

       
    }
}
