using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvokeEnemy : MonoBehaviour
{
    enum Tipo
    {
        mago, king
    }
    public Slider mainSlider;
    [SerializeField]private Tipo tipo;
    private GameObject player;
    [SerializeField] private float Speed = 1, liveTank=2;
    public bool destroy = false;
    private SpriteRenderer spriteRenderer;
    private float diferencia,range;
    [SerializeField] private GameObject projectilePrefab, Item;
    [SerializeField] private Transform[] positions;
    private bool invoke;
    [SerializeField] private float invokeTime,invokeDelay;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovement.Instance.gameObject;
        invokeDelay = 10;
        invokeTime = 4;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (tipo==Tipo.king)
        {
            range = 25;

        }
        else
        {
            range = 8;
        }
        mainSlider.maxValue = liveTank;
        mainSlider.value = liveTank;
    }

    // Update is called once per frame
    void Update()
    {
        if (!destroy)
        {
            mainSlider.value = liveTank;
            diferencia = Vector3.Distance(transform.position, player.transform.position);
            invokeTime -= Time.deltaTime;
            if (diferencia>=range || invoke)
            {
               
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);

            }
            else if (invokeTime<=0)
            {
                invoke = true;
                InvokeSlime();
                StartCoroutine(relod());
                invokeTime = invokeDelay;
            }
        
        

        }
            
    }
    private void InvokeSlime()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, positions[i].transform.position, Quaternion.identity);
        }
    }
    public void Destroide()
    {
        liveTank--;
        if (liveTank == 0)
        {
            if (tipo == Tipo.king)
            {
                GlobalContador.Instance.DeadKind=true;

            }
            GlobalContador.Instance.PassOleada();
            GameObject projectile = Instantiate(Item, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }



    }
    IEnumerator relod()
    {
       yield return new WaitForSeconds(invokeDelay-2);
        invoke = false;
    }
}
