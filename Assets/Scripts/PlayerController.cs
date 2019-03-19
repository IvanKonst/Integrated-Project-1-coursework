using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 30;
    public GameObject Camera;
    public GameObject Bulletcast;
    public GameObject bullet;
    public int Ammocount=10;
    public Text ammoText;
    private bool Ammo = true;
    public Transform Camerareference;
    public GameObject Playerreference;
    public GameObject Cubereference;
    private Animator anim;
    private int lanepositioncheck;
    private float laneposition1= -3.08f;
    private float laneposition2 = -0.22f;
    private float laneposition3 = 2.74f;
    private float z;

    void Start ()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        //Camerareference = Camera.transform;
	}

    void Update()
    {
        UpdateAmmoText();
        if (Input.GetKey(KeyCode.W))
        {
          /*  if (lanepositioncheck < laneposition3) lanepositioncheck++;
            switch (lanepositioncheck)
            {
                case 1:
                    z = laneposition1;
                    break;
                case 2:
                    z = laneposition2;
                    break;
                case 3:
                    z = laneposition3;
                    break;
            }*/
            gameObject.transform.Translate(-Vector3.forward * (moveSpeed/3) * Time.deltaTime);
          //  gameObject.transform.SetPositionAndRotation(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, z), gameObject.transform.rotation);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.forward * (moveSpeed / 3) * Time.deltaTime);
            // Player.transform.Translate(Vector3.forward * (moveSpeed/3) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Camerareference.transform.localPosition = Camera.transform.localPosition;
            gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            Playerreference.transform.localRotation = Quaternion.Euler(0, 180, 0);
            // Camera.transform.localRotation = Quaternion.Euler(0, -180, 0);
            // Camera.transform.localPosition = Camerareference.transform.localPosition;
            //Camerareference=Camera.transform;
            // Camera.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            anim.SetInteger("Moveback", 1);
        }
        else
        {
            anim.SetInteger("Moveback", 0);

        }
       
        if (Input.GetKey(KeyCode.D))
        {
           gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            Playerreference.transform.localRotation = Quaternion.Euler(0, 0, 0);
            anim.SetInteger("AnimPar", 1);
            // Camera.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            
        }
        else
        {
            anim.SetInteger("AnimPar", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
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

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            Camera.transform.Translate(Vector3.forward * (moveSpeed*3) * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Camera.transform.Translate(Vector3.back * (moveSpeed*3) * Time.deltaTime);
        }

    }

    private void Awake()
    {
        
    }
    public void UpdateAmmoText()
    {
        ammoText.text = "Bullets: " + Ammocount;
    }
}
