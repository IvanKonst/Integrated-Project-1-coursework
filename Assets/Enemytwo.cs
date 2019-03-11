using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytwo : MonoBehaviour
{
    public GameObject PlayerController;
    private float moveSpeed = 30;
    public float Enemymovespeed=10;
    private float range=30;
    public GameObject Bulletcast;
    public Rigidbody bullet;
    public Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.localPosition, PlayerController.transform.localPosition)<=range)
        {
           // gameObject.transform.Translate(Vector3.right * Enemymovespeed * Time.deltaTime);

        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            Rigidbody bulletInstance = Instantiate(bullet, Bulletcast.transform.position, Bulletcast.transform.rotation);
            bulletInstance.transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}
