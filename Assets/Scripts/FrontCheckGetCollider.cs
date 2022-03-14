using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCheckGetCollider : MonoBehaviour
{
    public bool isFrontClimbable = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "grappleWall")
        {
            isFrontClimbable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFrontClimbable = false;
    }
}
