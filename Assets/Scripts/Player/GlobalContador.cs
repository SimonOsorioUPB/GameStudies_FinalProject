using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using TMPro;
public class GlobalContador : MonoBehaviour
{
    public int levelProjectile=0;
    public int levelPlayer=0;
    public int live=3;
    public int levelSpeed =0;
    public int killcount = 0;
    private PlayerMovement Jugador;
    public TMP_Text Oleada_text;
    public TMP_Text KillText;
    public TMP_Text Live_text;
    public TMP_Text Size_text;
    public TMP_Text Projectile_text;
    public int Oleada;
    public int enemiDeadForOleada=0;
    [SerializeField] private int[] EnemyNeed;
    public static GlobalContador Instance { get; set; }

    void Awake()
    {
        Live_text.text = ""+3;
        Size_text.text = "" + 0;
        Jugador = gameObject.GetComponentInChildren<PlayerMovement>();
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
                Chagelive();
            }

        }
    }
    public void Chagelive()
    {
        Size_text.text = "" + levelPlayer;
        Live_text.text = "" + live;
        Projectile_text.text = "" + levelProjectile;
    }
    public void PassOleada()
    { 

        enemiDeadForOleada++;
        killcount++;
        KillText.text = "" + killcount;
        if (EnemyNeed[Oleada] <= enemiDeadForOleada)
        {
            enemiDeadForOleada = 0;
            Oleada++;
            Oleada_text.text = ""+(Oleada+1);
            Debug.Log("pasaste de oleada");
        }
      
    }


}
