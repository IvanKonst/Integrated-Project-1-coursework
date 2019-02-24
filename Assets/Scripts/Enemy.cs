using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy
{
    public float maxHealth;
    public float currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
