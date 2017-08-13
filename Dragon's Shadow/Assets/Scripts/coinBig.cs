using UnityEngine;
using System.Collections;

public class coinBig : MonoBehaviour {
	
	public AudioClip coinpickup;
	HUDScript hud;
	
	void OnTriggerEnter(Collider other)
	{
		PlayerPhysics physics = other.gameObject.GetComponent<PlayerPhysics>();
		if (physics)
		{
			AudioSource.PlayClipAtPoint(coinpickup,transform.position);
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			gameObject.renderer.enabled = false;
			hud.IncreaseScore(5000);
			Destroy(gameObject);
		}
	}
}