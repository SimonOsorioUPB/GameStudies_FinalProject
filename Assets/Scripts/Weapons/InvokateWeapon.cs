using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokateWeapon : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    private bool invoke;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float invokeTime, invokeDelay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        invokeTime-= Time.deltaTime;
        if (invokeTime <= 0)
        {
            invoke = true;
            InvokeSlime();
            invokeTime = invokeDelay;
        }

    }
    private void InvokeSlime()
    {
        int position = GlobalContador.Instance.levelInvoke;
        if (position >= 4)
        {
            invokeDelay = GlobalContador.Instance.TimeInvoke;
               position = 4;

        }
        for (int i = 0; i < position; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, positions[i].transform.position, Quaternion.identity);
        }
    }
}
