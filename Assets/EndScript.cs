using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour 
{
    public GameObject playerreference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag=="Player")
        {
            Debug.Log("asd");
            SceneManager.LoadScene("end");
        }
    }
}
