using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public AudioClip deathClip;
	public AudioClip confirmClip;
	//public AudioClip deathClip;//death soundclip
	public AudioClip slideClip; //slide soundclip
	public AudioClip jumpClip; //jump soundclip
	public AudioClip sweepClip;
	public AudioClip jumpkickClip;


	bool mPlayerDead = false;
	bool paused = false;
	Animator anim;
	//int wallclingHash = Animator.StringToHash ("Wall Cling");
	//int walljumpHash = Animator.StringToHash ("Wall Jump");
	//int runHash = Animator.StringToHash ("runMei");
	//int slideHash = Animator.StringToHash ("slideMei");
	int slideupHash = Animator.StringToHash ("slideupMei");
	//int crouchHash = Animator.StringToHash ("crouchMei");
	//int idleHash = Animator.StringToHash ("idleMei");
	int uncrouchHash = Animator.StringToHash ("uncrouchMei");
	//int onWallHash = Animator.StringToHash ("onWallMei");
	//int walljumpHash = Animator.StringToHash ("jumpWallMei");
	//int jumpneutralHash = Animator.StringToHash("jumpNeutralMei");
	//int jumpHash = Animator.StringToHash("jumpMei");
	//int landHash = Animator.StringToHash ("landMei");
	//int sweepHash = Animator.StringToHash ("attackSweepMei");
	//int jumpkickHash = Animator.StringToHash ("attackJumpkickMei");
	int deathHash = Animator.StringToHash ("deathMei");
	//int attacksweepStateHash = Animator.StringToHash ("Base Layer.attackSweepMei");
	int runStateHash = Animator.StringToHash("Base Layer.runMei");
	int run2StateHash = Animator.StringToHash("Base Layer.runMei 0");
	int idleStateHash = Animator.StringToHash("Base Layer.idleMei");
	int slideStateHash = Animator.StringToHash("Base Layer.slideMei");
	int crouchStateHash = Animator.StringToHash ("Base Layer.crouchMei");
	int jumpneutralStateHash = Animator.StringToHash ("Base Layer.jumpNeutralMei");
	int jumpStateHash = Animator.StringToHash ("Base Layer.jumpMei");
	//int slideStateHash = Animator.StringToHash("Base Layer.Slide");
	PlayerPhysics mPlayer;
	bool mHasControl;
	bool attack;
	bool crouch;

	//GameObject enemy;
	//GameObject itemdestroy;
	//public float hitboxSpeed = 600.0f;
	//public Transform hitboxSpawn;
	//public Rigidbody hitboxPrefab;
	//Rigidbody clone;


	//bool climbing = false;
	//bool facingRight = true;
	//public float moveDirection;

	//public AudioClip SlideClip;
	//public AudioClip Footsteps;
	


	void Start () 
	{
		//enemy = GameObject.FindGameObjectWithTag ("Enemy");
		//itemdestroy = GameObject.FindGameObjectWithTag ("Destructible");



		anim = GetComponent<Animator> ();


		mHasControl = true;
		mPlayer = GetComponent<PlayerPhysics>();
		if (mPlayer == null)
			Debug.LogError("This object also needs a PlayerPhysics component attached for the controller to function properly");
	}

	//void Awake(){
		//hitboxSpawn = GameObject.Find ("hitboxSpawn").transform;
	//}

	void Update () 
	
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			AudioSource.PlayClipAtPoint(confirmClip, transform.position);
			GiveControl ();
			paused = togglePause ();

		}

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", move); //animator speed float
		attack = Input.GetButtonDown ("Attack");
		crouch = Input.GetKeyDown (KeyCode.DownArrow);

		/*
		if(move > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(move < 0 && facingRight)
			// ... flip the player.
			Flip();
	*/
				//here are the actions that are triggered by a press or a release
				if (mPlayer && mHasControl) {
						
		

						/*if (Input.GetKeyDown (KeyCode.LeftShift))
								//{
								//AudioSource.PlayClipAtPoint(Footsteps, transform.position);
								//}
								mPlayer.StartSprint ();
			
						if (Input.GetKeyUp (KeyCode.LeftShift))
								mPlayer.StopSprint ();
			*/
						if (Input.GetKeyDown (KeyCode.DownArrow))
								//{
								//AudioSource.PlayClipAtPoint(SlideClip, transform.position);
								//}

								mPlayer.Crouch ();
			
			
						if (Input.GetKeyUp (KeyCode.DownArrow))
								mPlayer.UnCrouch ();
			
						
						//animator state section
						
						AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo (0);

						//croucn animation trigger
						if (move == 0 && crouch && stateInfo.nameHash == idleStateHash) { 
								anim.Play("crouchMei");
								//anim.SetTrigger (crouchHash);
								mPlayer.accelerationWalking = 0;
						}

						//uncrouch animation trigger
						if (Input.GetKeyUp (KeyCode.DownArrow) && stateInfo.nameHash == crouchStateHash) { 
								anim.SetTrigger (uncrouchHash);	
								mPlayer.accelerationWalking = 50;
						}
						
						

						//slide animation trigger
						if (move > 0 && crouch && stateInfo.nameHash == runStateHash) {
							AudioSource.PlayClipAtPoint (slideClip, transform.position);
							anim.Play ("slideMei");
						} 
						if (move < 0 && crouch && stateInfo.nameHash == run2StateHash) {
							AudioSource.PlayClipAtPoint (slideClip, transform.position);
							anim.Play ("slideMei");
						}
						if (move < 0 && crouch && stateInfo.nameHash == runStateHash) {
							AudioSource.PlayClipAtPoint (slideClip, transform.position);
							anim.Play ("slideMei");
						}
						//slide get up animation trigger
						if (Input.GetKeyUp (KeyCode.DownArrow) && stateInfo.nameHash == slideStateHash) {
							anim.SetTrigger (slideupHash);
							AudioSource.PlayClipAtPoint (jumpClip, transform.position);
						}
			
						//jump animation only while running
						if (Input.GetButton ("Jump") && stateInfo.nameHash == runStateHash) {
							anim.Play ("jumpMei");
						}

						if (Input.GetButton ("Jump") && stateInfo.nameHash == run2StateHash) {
							anim.Play ("jumpMei");
						}

						//neutral jump animation
						if (Input.GetButton ("Jump") && stateInfo.nameHash == idleStateHash) {
								anim.Play ("jumpNeutralMei");
								
						}
						if (move == 0 && attack && stateInfo.nameHash == crouchStateHash){ 
								//anim.SetTrigger (sweepHash);
								SweepAttack ();
								//clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
								//clone.AddForce (hitboxSpawn.transform.right * hitboxSpeed);
						}
						if (attack && move == 0 && stateInfo.nameHash == idleStateHash){ 
							//anim.SetTrigger (sweepHash);
								SweepAttack();
								//AudioSource.PlayClipAtPoint(sweepClip, transform.position);
								//anim.Play ("attackSweepMei");
							//clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
							//clone.AddForce (hitboxSpawn.transform.right * hitboxSpeed);
				
						}

						
						if (attack && move > 0 && stateInfo.nameHash == runStateHash){ 
								//anim.SetTrigger (jumpkickHash);
								JumpKick ();
								//clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
								//clone.AddForce (hitboxSpawn.transform.right * hitboxSpeed);
								//yield return new WaitForSeconds (animation.clip.length);
								//anim.Play ("idleMei");
						}
						if (attack && move < 0 && stateInfo.nameHash == run2StateHash){ 
								//anim.SetTrigger (jumpkickHash);
								JumpKick ();
								//clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
								//clone.AddForce (hitboxSpawn.transform.right * hitboxSpeed);
						} 
						if (attack && move < 0 && stateInfo.nameHash == runStateHash){ 
								JumpKick ();
						} 
						if (attack && move < 0 && stateInfo.nameHash == run2StateHash){ 
								//anim.SetTrigger (jumpkickHash);
								JumpKick ();
								//clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
								//clone.AddForce (hitboxSpawn.transform.right * hitboxSpeed);
						} 
						if (attack && stateInfo.nameHash == jumpneutralStateHash){ 
								//anim.SetTrigger (jumpkickHash);
								JumpKick ();				
								
								//clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
								//clone.AddForce (hitboxSpawn.transform.right * -hitboxSpeed);
						} 
						if (attack && stateInfo.nameHash == jumpStateHash){ 
								//anim.SetTrigger (jumpkickHash);
								JumpKick ();
								
								//clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
								//clone.AddForce (hitboxSpawn.transform.right * hitboxSpeed);
			} 

		}
	}

	void SweepAttack ()
	{
		AudioSource.PlayClipAtPoint (sweepClip, transform.position);
		anim.Play ("attackSweepMei");
	}

	void JumpKick()
	{
		anim.Play ("attackJumpkickMei");
		AudioSource.PlayClipAtPoint (jumpkickClip, transform.position);
	}
	void StartedJump()
	{
		AudioSource.PlayClipAtPoint(jumpClip, transform.position);
		anim.Play ("jumpMei");
	}

	//animation for wall hang
	void LandedOnWall()
	{
		if (!mPlayerDead){// && !enemy){ //&& !itemdestroy) {
			anim.Play ("onWallMei");
		}
		//anim.SetTrigger (onWallHash);
	}
	
	//animation and sound for wall jump
	void StartedWallJump()
	{
		//transform.Rotate (Vector3.up, 180.0f, Space.World);		
		AudioSource.PlayClipAtPoint(jumpClip, transform.position);
		anim.Play ("jumpMei");
		//anim.SetTrigger (walljumpHash);
	}


	void LandedOnGround()
	{
		if (!GetComponent<PlayerPhysics>().IsCrouching() && !mPlayerDead)
		{
			anim.Play("runMei");
		}
	}
	
	void GoLeft()
	{
		//anim.Play ("runMei 0");
		//anim.SetTrigger (runHash);
		//rigidbody.transform.Rotate (Vector3.up, -180.0f, Space.World);

		Vector3 localScale = rigidbody.transform.localScale;
		localScale.z = -Mathf.Abs(localScale.z);
		rigidbody.transform.localScale = localScale;

	}

	void GoRight()
	{
		//anim.Play ("runMei");
		//anim.SetTrigger (runHash);
		//rigidbody.transform.Rotate (Vector3.up, 180.0f, Space.World);

		Vector3 localScale = rigidbody.transform.localScale;
		localScale.z = Mathf.Abs(localScale.z);
		rigidbody.transform.localScale = localScale;
	}


	
	public void PlayerDied()
	{
		AudioSource.PlayClipAtPoint(deathClip,transform.position);
		//anim.Play ("deathMei");
		//anim.enabled = false;
		anim.SetTrigger (deathHash);
		mPlayerDead = true;


		//animation.Stop();
	}
	
	public void PlayerLives()
	{
		GoRight ();
		anim.ResetTrigger("deathMei");
		//anim.ResetTrigger("Action.deathMei");
		//anim.ResetTrigger (deathHash);
		anim.Play ("idleMei");
		//GoRight();
		//mPlayer.Reset ();
		mPlayerDead = false;


	}
	//Pause Menu
	void OnGUI()
	{
		//font style
		GUIStyle myStyle = new GUIStyle ();//(GUI.skin.button);
		myStyle.fontSize = 50;

		//load font
		Font myFont = (Font)Resources.Load("Fonts/dubsetp_dungeons", typeof(Font));
		myStyle.font = myFont;

		//set color for mouseover
		myStyle.normal.textColor = Color.white;
		myStyle.hover.textColor = Color.red;

		if(paused)
		{
			//AudioSource.PlayClipAtPoint(confirmClip, transform.position);
			RemoveControl ();
			GUILayout.Label ("PAUSED!", myStyle);
			if(GUILayout.Button("Continue")){
				//AudioSource.PlayClipAtPoint(confirmClip, transform.position);
				paused = togglePause();
				GiveControl();
			}
			if(GUILayout.Button ("Last Checkpoint")){
				//AudioSource.PlayClipAtPoint(confirmClip, transform.position);
				PlayerLives ();
				mPlayer.Reset();
				GiveControl();
				paused = togglePause ();
				GiveControl ();
			}
			if(GUILayout.Button ("Restart Level")){
				//AudioSource.PlayClipAtPoint(confirmClip, transform.position);
				Application.LoadLevel(Application.loadedLevel);
				paused = togglePause();
				GiveControl ();
			}
			if(GUILayout.Button ("Main Menu")){
				//AudioSource.PlayClipAtPoint(confirmClip, transform.position);
				Application.LoadLevel(0);
				paused = togglePause();
				GiveControl ();
			}
			if(GUILayout.Button ("Quit Game")){
			//AudioSource.PlayClipAtPoint(confirmClip, transform.position);
				Application.Quit();
			}
		}
	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}

	/*
	public void jumpKickEvent(){
		clone = Instantiate (hitboxPrefab, hitboxSpawn.position, hitboxSpawn.rotation) as Rigidbody;
		clone.AddForce (hitboxSpawn.transform.right * hitboxSpeed);

	}*/

	void FixedUpdate()
	{

		
		if (mPlayer && mHasControl)
		{
			if (Input.GetButton ("Jump"))
			{
				mPlayer.Jump();
				
			}

			mPlayer.Walk(Input.GetAxisRaw("Horizontal")); //movement input
			//anim.SetFloat ("vSpeed", rigidbody.velocity.y); //animator float
		}
	}


	public void GiveControl() { mHasControl = true; }
	public void RemoveControl() { mHasControl = false; }
	public bool HasControl() { return mHasControl; }

	/*
void Flip(){
		
		// Switch the way the player is labelled as facing
		facingRight = !facingRight;
		
		//Multiply the player's x local cale by -1
		transform.Rotate (Vector3.up, 180.0f, Space.World);
	} 
*/
}

