using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D myController;
    public float runSpeed = 40f;
    public Animator myAnimator;
    public SoundManager soundManScript;
    public bool running;

    CircleCollider2D myCollider;
    public float horizontalMove = 0f;
    bool jump = false;

    private void Start()
    {
        soundManScript = FindObjectOfType<SoundManager>();
        myCollider = GetComponent<CircleCollider2D>();
    }
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
        {
            running = true;
            myAnimator.SetBool("Running", true);
        }
        else
        {
            running = false;
            myAnimator.SetBool("Running", false);
        }
    }

    private void FixedUpdate()
    {
        myController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
