using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IEnemy, IHeal
{
    public Text Healthbar;
    public Text Kills;
    int Healtha = 100;
    int Killsa = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateKills();
    }

    public void TakeDamage(int amount)
    {
        Healtha -= amount;
        UpdateHealth();
        if (Healtha <= 0)
            Die();
    }

    void Die()
    {

        SceneManager.LoadScene("mainscenev2");
        Time.timeScale = 1;
    }

    public void UpdateHealth()
    {
        Healthbar.text = "Health: " + Healtha;
    }

    public void UpdateKills()
    {
        Kills.text = "Kills: " + Killsa;
    }

    public void Healonkill(int amount)
    {
        Killsa += 1;
        int randValue = Random.Range(0, 100);
        if (randValue < 15)
        {
            Healtha += amount;
            if (Healtha >= 100)
            {
                Healtha = 100;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Endwall")
        {
            if (Killsa >= 20)
            {
                Debug.Log("asd");
                SceneManager.LoadScene("end");
            }
        }
    }
}
