using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private Animator myAnimator;
	private FrontCheckGetCollider myFrontCheck;
	private bool walkingSound;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	public bool isTouchingFront;
	public Transform frontCheck;
	public bool wallSliding;
	public float wallSlidingSpeed;
	PlayerMovement myMovement;
	public bool wallJumping;
	public float xWallForce;
	public float yWallForce;
	public float wallJumpTime;
	public float maxGrappleRange = 20f;
	public SoundManager soundManScript;
	private bool allowWallJump = true;
	private float attackCountdown = 0.5f;
	public bool stopAttack;
	Vector2 direction;
	public int playerHealth = 3;
	private float invulnerability = 2.0f;
	public int coinCount = 0;
	private bool collectedGrapple = false;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		myMovement = FindObjectOfType<PlayerMovement>();
		myFrontCheck = FindObjectOfType<FrontCheckGetCollider>();
		soundManScript = FindObjectOfType<SoundManager>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				myAnimator.SetBool("Jumping", false);
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

		if (invulnerability > 0.0f)
        {
			invulnerability -= Time.deltaTime;
        }
	}

    private void Update()
    {
		isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, k_GroundedRadius, m_WhatIsGround);

		attackCountdown -= Time.deltaTime;

		if (stopAttack == true)
		{
			stopAttack = false;
			myAnimator.SetBool("Attacking", false);
		}

		if (isTouchingFront == true && m_Grounded == false && Input.GetAxisRaw("Horizontal") != 0 && myFrontCheck.isFrontClimbable == true)
		{
			myAnimator.SetBool("WallSliding", true);
			wallSliding = true;
		}
		else
		{
			myAnimator.SetBool("WallSliding", false);
			wallSliding = false;
		}

		if (wallSliding == true)
		{
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Mathf.Clamp(m_Rigidbody2D.velocity.y, -wallSlidingSpeed, float.MaxValue));
		}
		if (Input.GetButtonDown("Jump") && wallSliding == true)
		{
			wallJumping = true;
			Invoke("SetWallJumpingToFalse", wallJumpTime);
		}
		if (wallJumping == true && allowWallJump == true)
		{
			StartCoroutine(CountdownWalljump());
			//m_Rigidbody2D.AddForce(new Vector2(-myMovement.horizontalMove / 10, m_JumpForce / 75));
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			myAnimator.SetBool("Jumping", true);
			soundManScript.PlaySound("jumpEffort");
		}

		//Attack inputs
		if (Input.GetButtonDown("Fire1") && attackCountdown <= 0)
        {
			attackCountdown = 0.5f;
			myAnimator.SetBool("Attacking", true);
			soundManScript.PlaySound("sword");
		}

		if (m_Grounded == true && myMovement.running == true)
        {
			StartCoroutine(WalkingSounds());
        }
	}

	IEnumerator CountdownWalljump()
    {
		allowWallJump = false;
		yield return new WaitForSeconds(0.5f);
		allowWallJump = true;
    }

	public void TakeDamage()
    {
		if (invulnerability <= 0.0f)
        {
			playerHealth--;
			invulnerability = 2.0f;
        }
    }

	public void AddCoins()
    {
		soundManScript.PlaySound("coin");
		coinCount += 5;
    }

	public void GrappleToWall(Transform grapTrans)
    {
		//soundManScript.PlaySound("grappleReel");
		soundManScript.PlaySound("grappleAttach");
		m_Grounded = false;
		var pointer = grapTrans.position - gameObject.transform.position;
		var distance = pointer.magnitude;
		direction = pointer / distance;
		if (grapTrans.transform.position.x > gameObject.transform.position.x)
		{
			//m_Rigidbody2D.AddForce(new Vector2(grapTrans.transform.position.x, grapTrans.transform.position.y).normalized * 1000);
			m_Rigidbody2D.AddForce(new Vector2(1000,1000));
		}
		else
        {
			//m_Rigidbody2D.AddForce(new Vector2(-grapTrans.transform.position.x, grapTrans.transform.position.y).normalized * 1000);
			m_Rigidbody2D.AddForce(new Vector2(-1000, 1000));
		}
		myAnimator.SetBool("Jumping", true);
	}

    void SetWallJumpingToFalse()
    {
		wallJumping = false;
    }

	IEnumerator WalkingSounds()
	{
		if (walkingSound == false)
		{
			walkingSound = true;
			soundManScript.PlaySound("walking");
			yield return new WaitForSeconds(0.2f);
			walkingSound = false;
		}
	}

	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			myAnimator.SetBool("Jumping", true);
			soundManScript.PlaySound("jumpEffort");
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		/*Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;*/

		transform.Rotate(0f, 180f, 0f);
	}
}
