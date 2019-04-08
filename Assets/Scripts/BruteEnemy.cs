using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BruteEnemy : MonoBehaviour, IEnemy
{
    public float Enemymovespeed = 6;
    private Transform PlayerController;
    private float range = 20;
    public GameObject Bulletcast;
    public GameObject bullet;
    public float timebetweenshots = 1f;
    public float starttime = 1f;
    public float maxHealth;
    public float currentHealth;
    public float moveSpeed = 30;
    public static GameObject[] Enemies;
    public int numSpawned = 0;
    public int enemycount;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Enemies = Resources.LoadAll<GameObject>("Enemy");
        enemycount = numSpawned;
        timebetweenshots = starttime;
        anim = gameObject.GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerController = GameObject.FindGameObjectWithTag("Player").transform;

        if (PlayerController.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            anim.SetFloat("Animpar", 1);
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            anim.SetFloat("Animpar", 1);
        }

        if (Vector3.Distance(gameObject.transform.localPosition, PlayerController.transform.localPosition) > range)
        {
            if (PlayerController.transform.position.x > gameObject.transform.position.x)
            {
                Vector3 vec = new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y, gameObject.transform.position.z);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, vec, Enemymovespeed * Time.deltaTime);
                anim.SetFloat("Animpar", 1);
            }
            else
            {
                Vector3 vec = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y, gameObject.transform.position.z);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, vec, Enemymovespeed * Time.deltaTime);
                anim.SetFloat("Animpar", 1);
            }

        }
        else
        {

            if (timebetweenshots <= 0)
            {
                GameObject bulletInstance = Instantiate(bullet, Bulletcast.transform.position, Bulletcast.transform.rotation);
                bulletInstance.GetComponent<EnemyBulletScript>().Direction = Bulletcast.transform.right;
                timebetweenshots = starttime;
            }
            else
            {
                timebetweenshots -= Time.deltaTime;
            }
            anim.SetFloat("Animpar", 0);

        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            anim.SetFloat("Dead", 1);
            Invoke("Die", 1.10f);
        }
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
