using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytwo : MonoBehaviour
{
    public GameObject PlayerController;
    public float Enemymovespeed=10;
    private float range=30;
    public GameObject Bulletcast;
    public GameObject bullet;
    public float timebetweenshots=10f;
    public float starttime=10f;

    // Start is called before the first frame update
    void Start()
    {
        timebetweenshots = starttime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.localPosition, PlayerController.transform.localPosition)<=range)
        {
           transform.position = Vector3.MoveTowards(transform.position, PlayerController.transform.position, Enemymovespeed * Time.deltaTime);
        }
        if(timebetweenshots <=0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timebetweenshots = starttime;
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }
    }
}
