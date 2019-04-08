using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RechargePort : MonoBehaviour
{
    private Transform PlayerController;
    private float range = 4;
    private int Ammo = 32;

    void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.localPosition, PlayerController.transform.localPosition) < range)
        {
            PlayerController.transform.GetComponent<IPorts>().Ammoadd(Ammo);
        }
    }
}
