using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSlime : MonoBehaviour
{
    enum Tipo
    {
        Normal,spedy,tank
    }
    [SerializeField]private Tipo identificator = Tipo.Normal;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            if (identificator == Tipo.Normal)
            {
                col.gameObject.GetComponent<PlayerMovement>().levelrign(1);
            }
            if (identificator == Tipo.spedy)
            {
                col.gameObject.GetComponent<PlayerMovement>().LevelSpeed(1);
            }
            if (identificator == Tipo.tank)
            {
                GlobalContador.Instance.live++;
                GlobalContador.Instance.Chagelive();
                Debug.Log("tienes mas vida");

            }

            Destroy(gameObject);

        }
    }
}