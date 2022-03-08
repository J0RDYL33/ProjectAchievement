using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Transform firePoint;
    public GameObject grapplePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(grapplePrefab, firePoint.position, firePoint.rotation);
    }
}
