using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytwo : MonoBehaviour
{
    public float Enemymovespeed = 10;
    private Transform PlayerController;
    private float range = 20;
    public GameObject Bulletcast;
    public GameObject bullet;
    public float timebetweenshots = 10f;
    public float starttime = 10f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
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
}
