using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool dead;
    void Start()
    {
        currentHealth = maxHealth;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            dead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void HealthUP (int heal)
    {
        currentHealth += heal;
    }
}
