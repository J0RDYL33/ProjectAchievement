using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Transform firePoint;
    public GameObject grapplePrefab;
    private float fireTimer = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && fireTimer <= 0)
        {
            Shoot();
            fireTimer = 3.0f;
        }

        fireTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(grapplePrefab, firePoint.position, firePoint.rotation);
    }
}
