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
    void Start ()
    {

        //Camerareference = Camera.transform;
	}

    void Update()
    {
        UpdateAmmoText();
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(-Vector3.forward * (moveSpeed/3) * Time.deltaTime);
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
        }

        if (Input.GetKey(KeyCode.D))
        {
           gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            Playerreference.transform.localRotation = Quaternion.Euler(0, 0, 0);
            // Camera.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
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
    public void UpdateAmmoText()
    {
        ammoText.text = "Bullets: " + Ammocount;
    }
}
