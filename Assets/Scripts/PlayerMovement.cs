using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D myController;
    public float runSpeed = 40f;
    public Animator myAnimator;

    float horizontalMove = 0f;
    bool jump = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Handle animation
        if (horizontalMove != 0)
            myAnimator.SetBool("Running", true);
        else
            myAnimator.SetBool("Running", false);
    }

    private void FixedUpdate()
    {
        myController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
