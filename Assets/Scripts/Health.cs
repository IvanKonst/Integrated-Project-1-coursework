using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IEnemy, IHeal
{
    public Text Healthbar;
    int Healtha = 100;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
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

    public void Healonkill(int amount)
    {
        int randValue = Random.Range(0, 100);
        if (randValue < 15)
        {
            Healtha += amount;
        }
    }
}
