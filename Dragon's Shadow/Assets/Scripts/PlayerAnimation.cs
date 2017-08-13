using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
	public AudioClip deathClip; //death soundclip
	public AudioClip slideClip; //slide soundclip
	public AudioClip jumpClip; //jump soundclip
	
	public Transform animatedPlayerModel; //Animated model that will have all the animations in it
	bool mPlayerDead = false;
	bool mIdle = false;
	
	void Start () 
	{
		//Do some error checks first
		if (animatedPlayerModel == null)
		{
			Debug.LogError("The animated player model is not set.");
			this.enabled = false;
		}
		else if (!CheckAnims())
		{
			Debug.LogError("The animated player model does not seem to have the appropriate animations needed.");
			this.enabled = false;
		}
		else
		{
			//no errors
			animatedPlayerModel.animation["idleMei"].speed = 0;
		}
	}
	
	bool CheckAnims()
	{
		if (!animatedPlayerModel)
			return false;
		
		if (animatedPlayerModel.animation["runMei"] == null ||
		    animatedPlayerModel.animation["jumpMei"] == null ||
		    animatedPlayerModel.animation["slideMei"] == null ||
		    animatedPlayerModel.animation["slideupMei"] == null ||
		    animatedPlayerModel.animation["deathMei"] == null ||
		    animatedPlayerModel.animation["onWallMei"] == null ||
		    animatedPlayerModel.animation["idleMei"] == null) return false;
		
		return true;
	}
	
	void Update () 
	{
		//recalculate walking speed
		float walkingSpeed = Mathf.Abs(rigidbody.velocity.x)*0.075f;
		animatedPlayerModel.animation["runMei"].speed = walkingSpeed;
		
		//switch to idle animation if needed
		if (walkingSpeed == 0 && animatedPlayerModel.animation["walk"].enabled)
		{
			animatedPlayerModel.animation.Play("idleMei");
			mIdle = true;
		}
		
		if (walkingSpeed > 0.01f && mIdle)
		{
			mIdle = false;
			animatedPlayerModel.animation.CrossFade("runMei");
		}
	}
	
	void PlayAnim(string animName)
	{
		if (!mPlayerDead)
		{
			
			animatedPlayerModel.animation.Play(animName);
			animatedPlayerModel.transform.localPosition = Vector3.zero; //reset any position change made by on wall anim
		}
	}
	
	void GoLeft()
	{
		Vector3 localScale = animatedPlayerModel.transform.localScale;
		localScale.z = -Mathf.Abs(localScale.z);
		animatedPlayerModel.transform.localScale = localScale;
	}
	
	void GoRight()
	{
		Vector3 localScale = animatedPlayerModel.transform.localScale;
		localScale.z = Mathf.Abs(localScale.z);
		animatedPlayerModel.transform.localScale = localScale;
	}
	
	public void PlayerDied()
	{
		AudioSource.PlayClipAtPoint(deathClip,transform.position);
		PlayAnim("deathMei");
		mPlayerDead = true;
	}
	
	public void PlayerLives()
	{
		GoRight();
		mPlayerDead = false;
		PlayAnim("runMei");
	}
	
	
	
	
	
	//MESSAGES CALLED BY PlayerPhysics.cs:
	void StartedJump()
	{
		AudioSource.PlayClipAtPoint(jumpClip, transform.position);
		
		PlayAnim("jumpMei");
	}
	
	void StartedWallJump()
	{
		AudioSource.PlayClipAtPoint(jumpClip, transform.position);
		PlayAnim("jumpMei");
	}
	
	void StartedCrouching()
	{
		AudioSource.PlayClipAtPoint(slideClip,transform.position);
		PlayAnim("slideMei");
	}
	
	void StoppedCrouching()
	{
		PlayAnim("slideupMei");
		
		if (GetComponent<PlayerPhysics>().IsOnWall())
			LandedOnWall();
		else
			animatedPlayerModel.animation.CrossFade("runMei", 2.0f);
	}
	
	void LandedOnGround()
	{
		if (!GetComponent<PlayerPhysics>().IsCrouching())
		{
			PlayAnim("runMei");
		}
	}
	
	void LandedOnWall()
	{
		if (!GetComponent<PlayerPhysics>().IsCrouching())
		{
			PlayAnim("onwallMei");
			
			if (!GetComponent<PlayerPhysics>().IsWallOnRightSide())
			{
				animatedPlayerModel.transform.localPosition = new Vector3(0.45f, 0, 0);
				GoLeft();
			}
			else
			{
				animatedPlayerModel.transform.localPosition = new Vector3(-0.45f, 0, 0);
				GoRight();
			}
		}
	}
	
	void ReleasedWall()
	{
		print("released");
		if (!animatedPlayerModel.animation["jumpMei"].enabled && !GetComponent<PlayerPhysics>().IsCrouching())
			PlayAnim("runMei");
	}
	
	void StartedSprinting()
	{
		//print("Start Sprint");
	}
	
	void StoppedSprinting()
	{
		//print("Stop Sprint");
	}
}

