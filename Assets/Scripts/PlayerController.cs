using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IPorts
{
    public float moveSpeed = 80;
    public GameObject Camera;
    private Transform Chargingports;
    public GameObject Bulletcast;
    public GameObject bullet;
    public int Ammocount = 32;
    public Text ammoText;
    private bool Ammo = true;
    private bool Isgrounded = true;
    public Transform Camerareference;
    public GameObject Playerreference;
    public GameObject Cubereference;
    private Animator anim;
    private float laneposition1= 0f;
    private float laneposition2 = 2.5f;
    private float laneposition3 = 5f;

    void Start ()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
	}

    void Update()
    {
        UpdateAmmoText();
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (gameObject.transform.position.z > 4f)
            {
                Vector3 vecz = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, laneposition2);
                gameObject.transform.position = vecz;
            }
            else if (gameObject.transform.position.z > 1f)
            {
                Vector3 vecz = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, laneposition1);
                gameObject.transform.position = vecz;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (gameObject.transform.position.z < 1f)
            {
                Vector3 vecz = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, laneposition2);
                gameObject.transform.position = vecz;
            }
            else if (gameObject.transform.position.z < 4f)
            {
                Vector3 vecz = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, laneposition3);
                gameObject.transform.position = vecz;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 vec = new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, vec , moveSpeed * Time.deltaTime);
            Playerreference.transform.localRotation = Quaternion.Euler(0, 180, 0);
            anim.SetInteger("Moveback", 1);
        }
        else
        {
            anim.SetInteger("Moveback", 0);

        }
       
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 vec = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, vec, moveSpeed * Time.deltaTime);
            Playerreference.transform.localRotation = Quaternion.Euler(0, 0, 0);
            anim.SetInteger("AnimPar", 1);
            
        }
        else
        {
            anim.SetInteger("AnimPar", 0);
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && (Isgrounded == true))
        {
            gameObject.transform.Translate(Vector3.up * moveSpeed * 2 * Time.deltaTime);
        }

        if ((Input.GetKeyDown(KeyCode.X)) && (Ammo == true) && (Ammocount !=0))
        {
            this.Ammo = false;
            GameObject bulletInstance = Instantiate(bullet, Bulletcast.transform.position, Bulletcast.transform.rotation);
            bulletInstance.GetComponent<BulletScript>().Direction = -Bulletcast.transform.right;
            this.Ammo = true;
            Ammocount--;
        }
        

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            Camera.transform.Translate(Vector3.forward * (moveSpeed*3) * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            Camera.transform.Translate(Vector3.back * (moveSpeed*3) * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Isgrounded = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Isgrounded = false;
        }
    }

    private void Awake()
    {
        
    }

    public void UpdateAmmoText()
    {
        ammoText.text = Ammocount + " / 32";
    }

    public void Ammoadd(int amount)
    {
        Ammocount = amount;
    }
}
