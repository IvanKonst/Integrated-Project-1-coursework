using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text Healthbar;
    public int Healtha = 100;
    public GameObject Playercontroller;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        Healthbar.text ="Health: " + Healtha;
    }
    public void TakeDamage()
    {
        
    }
    public void OnCollisionEnter(Collision bullet)
    {
        Healtha = Healtha - 5;
    }
}
