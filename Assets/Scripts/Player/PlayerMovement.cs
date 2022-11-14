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
    [SerializeField] private int nextLevel=10,nextLevelSpeed=8;
    public int puntaje =0;
    public int Speddpoints= 0;
    public int LevelSpeedi=0;

    
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
            transform.localScale = new Vector3(transform.localScale.x + 0.3f, transform.localScale.y + 0.3f, transform.localScale.z+ 0.3f);

            GlobalContador.Instance.live+=2;
           
            nextLevel = puntaje*2;
            puntaje = 0;
            GlobalContador.Instance.levelPlayer++;
            GlobalContador.Instance.levelProjectile++; 
            GlobalContador.Instance.Chagelive();
        }
    }
    internal void LevelSpeed(int level)
    {
        Speddpoints += level;
        if (Speddpoints >= nextLevelSpeed)
        {

            Debug.Log("se volvio mas rapido ");
            speed += 2;
            LevelSpeedi++;
            nextLevelSpeed = Speddpoints*2;
            Speddpoints = 0;
            GlobalContador.Instance.levelSpeed++;
            GlobalContador.Instance.Chagelive();
        }
    }
    internal void levenDown()
    { 

        transform.localScale = new Vector3(transform.localScale.x-0.3f, transform.localScale.y - 0.3f, transform.localScale.z - 0.3f);


       
    }
}
