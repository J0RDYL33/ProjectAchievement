using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineDestroyer : MonoBehaviour
{
    public GameObject flyObject;
    public FlyController hitFly;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "vines")
        {
            Destroy(other.transform.parent.gameObject);
        }

        if (other.gameObject.tag == "fly")
        {
            flyObject = other.transform.gameObject;
            hitFly = flyObject.GetComponent<FlyController>();
            hitFly.TakeHit();
        }
    }
}