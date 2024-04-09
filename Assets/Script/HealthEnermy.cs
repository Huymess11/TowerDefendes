using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnermy : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth;
    private GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MaxHealth <= 0)
        {
            Destroy(gameObject);
            gm.setEnermyAlive(1);
        }
    }
    public void TakeDame(int value)
    {
        MaxHealth -= value;
    }
}
