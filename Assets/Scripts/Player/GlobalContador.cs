using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalContador : MonoBehaviour
{
    public int levelProjectile=0;
    public int levelPlayer=0;
    public int live=3;
    public int levelSpeed =0;
    private PlayerMovement Jugador;
    public static GlobalContador Instance { get; set; }

    void Awake()
    {
        Jugador= gameObject.GetComponentInChildren<PlayerMovement>();
        if (Instance == null) { Instance = this; }
    }

    public void Dead()
    {
        if (live <= 0)
        {
            if (levelPlayer == 0)
            {
                Debug.Log("se murio");
                SceneManager.LoadScene("Gameloop");
            }
            else
            {
                levelPlayer--;
                live = 3;
                Jugador.levenDown();
            }

        }
    }


}
