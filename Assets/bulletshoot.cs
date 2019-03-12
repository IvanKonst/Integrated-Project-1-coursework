using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletshoot : MonoBehaviour
{
    public float speed;
    private Transform bulleta;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        bulleta = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(bulleta.position.x, bulleta.position.y, bulleta.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
