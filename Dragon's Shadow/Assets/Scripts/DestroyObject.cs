using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	public AudioClip explodeClip;
	public GameObject objectPrefab;
	private Vector3 explodePosition;	
	private float explodeForce = 200f;
	private bool _destroyed;
	//GameObject destructible;
	void Start(){
			//	destructible = GameObject.FindGameObjectWithTag ("Destructible");
		}
	void Update(){
		if(_destroyed){
			Destruction(explodePosition, explodeForce);
		}
	}

	public void Destruction(Vector3 explodePos, float force){
		GameObject pieces = Instantiate(objectPrefab, transform.position, transform.rotation) as GameObject;
		foreach(Transform child in pieces.transform){
			child.gameObject.rigidbody.AddExplosionForce(force,explodePos,10f);
			Destroy (this, 1f);
		}
		Destroy (gameObject);
	}
	
	void OnTriggerEnter(Collider other){
				//float rand = Random.value;
				if (other.tag == "hitbox") { 
						explodePosition = transform.position;
						{
							AudioSource.PlayClipAtPoint (explodeClip, transform.position);
							_destroyed = true;
							
						}
				}	
				if (other.tag == "Enemy") { 
						explodePosition = transform.position;
						{
							AudioSource.PlayClipAtPoint (explodeClip, transform.position);
							_destroyed = true;
							
						}
			}	
		}
}