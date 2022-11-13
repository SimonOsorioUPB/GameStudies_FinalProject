using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSlime : MonoBehaviour
{

   
    void Update()
    {
       
        Destroy(gameObject, 6);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") )
        {
            GlobalContador.Instance.UpdateInvoke();
            Destroy(gameObject);

        }
    }
    }
