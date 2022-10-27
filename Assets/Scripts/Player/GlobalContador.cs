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
    public static GlobalContador Instance { get; set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    public void Dead()
    {
        if (live <= 0)
        {
            Debug.Log("se murio");
            SceneManager.LoadScene("Gameloop");
        }
    }


}
