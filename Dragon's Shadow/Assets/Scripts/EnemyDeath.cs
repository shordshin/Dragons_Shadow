using UnityEngine;
using System.Collections;
using BreadcrumbAi;

public class EnemyDeath: MonoBehaviour {
	
	public AudioClip death;
	HUDScript hud;
	Animator anim;
	//GameObject enemy;
	//private Ai ai;
	//private bool _removeBody;
	//private string animPatrol = "patrolGuard";
	//private string animDeath = "deathGuard";


	//int deathHash = Animator.StringToHash ("deathGuard");
	void Start ()
	{
		//ai = GetComponent<Ai>();
		anim = GetComponent<Animator> ();
		//enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void FixedUpdate(){
		//Animation();
	}
	/*
	private void Animation(){
		if(ai.lifeState == Ai.LIFE_STATE.IsAlive){
			if(ai.moveState != Ai.MOVEMENT_STATE.IsIdle){
				anim.SetBool(animPatrol, true);
			} else {
				anim.SetBool(animPatrol, false);
			}

		} else if(ai.lifeState == Ai.LIFE_STATE.IsDead){
			anim.SetBool(animDeath, true);
		}
	}
*/
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "hitbox" ){
					
			AudioSource.PlayClipAtPoint(death,transform.position);
			anim.Play ("deathGuard");
			
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(2000);
			Destroy(GetComponent<Rigidbody>());
			Destroy(GetComponent<Collider>());
			Destroy(GetComponent<Ai>());	
			//enemy.collider.enabled = false;
			//yield return new WaitForSeconds(2f);
			Destroy(gameObject,3f);

		}

		if(other.gameObject.tag == "Destructible" ){
			
			AudioSource.PlayClipAtPoint(death,transform.position);
			anim.Play ("deathGuard");
			
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(2000);
			Destroy(GetComponent<Rigidbody>());
			Destroy(GetComponent<Collider>());
			Destroy(GetComponent<Ai>());	
			//enemy.collider.enabled = false;
			//yield return new WaitForSeconds(2f);
			Destroy(gameObject, 2f);
			
		}
	}


}



	