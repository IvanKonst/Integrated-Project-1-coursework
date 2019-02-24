using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 30;
    public GameObject Camera;
    public PlayerController Player;
    public GameObject Bulletcast;
    public GameObject bullet;
    public int Ammocount=10;
    public Text ammoText;
    private bool Ammo = true;

    void Start ()
    {
       
        
	}

    void Update()
    {
        UpdateAmmoText();
        if (Input.GetKey(KeyCode.W))
        {
            Player.transform.Translate(-Vector3.forward * (moveSpeed/3) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Player.transform.Translate(Vector3.forward * (moveSpeed/3) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
           // Camera.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Player.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
           // Camera.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.transform.Translate(Vector3.up * moveSpeed * 2 * Time.deltaTime);
        }

        if ((Input.GetKeyDown(KeyCode.X)) && (Ammo == true) && (Ammocount !=0))
        {
            this.Ammo = false;
            GameObject bulletInstance = Instantiate(bullet, Bulletcast.transform.position, Bulletcast.transform.rotation);
            bulletInstance.GetComponent<BulletScript>().Direction = Vector3.left;
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
        ammoText.text = Ammocount + "";
    }
}
