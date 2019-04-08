using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : MonoBehaviour
{
    public int Damage { get; set; }

    void Start()
    {
        Damage = 100;
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
    }

}