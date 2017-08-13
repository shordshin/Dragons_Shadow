using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
	
	public float maxSpeed = 10f;
	bool facingRight = true;
	
	Animator anim;
	
	//sets up the grounded stuff
	bool grounded = false;
	bool touchingWall = false; 
	public Transform groundCheck;
	public Transform wallCheck;
	float groundRadius = 0.2f;
	float wallTouchRadius = 0.2f;
	public LayerMask whatIsGround;
	public LayerMask whatIsWall;
	public float jumpForce = 700f;
	public float jumpPushForce = 10f;
	
	//double jump
	bool doubleJump = false;
	
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		touchingWall = Physics2D.OverlapCircle(wallCheck.position, wallTouchRadius, whatIsWall);
		anim.SetBool("Ground", grounded);
		
		if (grounded) 
		{
			doubleJump = false;
		}
		
		if (touchingWall) 
		{
			grounded = false; 
			doubleJump = false; 
		}
		
		anim.SetFloat ("vSpeed", rigidbody.velocity.y);
		
		
		
		float move = Input.GetAxis ("Horizontal");
		
		anim.SetFloat("Speed", Mathf.Abs (move));
		
		rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);
		
		// If the input is moving the player right and the player is facing left...
		if(move > 0 &&!facingRight){
			// ... flip the player.
			Flip ();
		}// Otherwise if the input is moving the player left and the player is facing right...
		else if(move < 0 && facingRight){
			// ... flip the player.
			Flip ();
		}
	}
	void Update()
	{
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
		{
			anim.SetBool("Ground", false);
			rigidbody.AddForce(new Vector2(0, jumpForce));
			
			if(!doubleJump && !grounded)
			{
				doubleJump = true;
			}
		}
		
		if (touchingWall && Input.GetButtonDown ("Jump")) 
		{
			WallJump ();
		}
		
	}
	
	void WallJump () 
	{
		rigidbody.AddForce (new Vector2 (jumpPushForce, jumpForce));
	}
	
	
	void Flip(){
		
		// Switch the way the player is labelled as facing
		facingRight = !facingRight;
		
		//Multiply the player's x local cale by -1
		transform.Rotate (Vector3.up, 180.0f, Space.World);
	}
}