using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy
{
    private Transform PlayerController;
    public float maxHealth;
    public float currentHealth;
    public float moveSpeed = 30;
    public static GameObject[] Enemies;
    public int numSpawned = 0;
    public int enemycount;



    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        Enemies = Resources.LoadAll<GameObject>("Enemy");
        enemycount = numSpawned;

    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        PlayerController = GameObject.FindGameObjectWithTag("Player").transform;
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
        if (enemycount < 20)
        {
            float[] lanepos = new float[] { 0f, 2.5f, 5f };
            int whichlane = Random.Range(0, lanepos.Length);
            int whichenemy = Random.Range(0, Enemies.Length);
            Vector3 spawnPos = new Vector3((Random.Range(PlayerController.transform.position.x - 60, PlayerController.transform.position.x - 85)), (2), (lanepos[whichlane]));
            GameObject enemy = Instantiate(Enemies[whichenemy]) as GameObject;
            enemy.transform.position = spawnPos;
            enemycount = enemycount + 1;
        }
    }
}
