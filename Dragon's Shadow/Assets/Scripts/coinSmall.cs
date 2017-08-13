using UnityEngine;
using System.Collections;

public class coinSmall : MonoBehaviour {

	public AudioClip coinpickup;
	HUDScript hud;

	void OnTriggerEnter(Collider other)
	{
		PlayerPhysics physics = other.gameObject.GetComponent<PlayerPhysics>();
		if (physics)
		{
			AudioSource.PlayClipAtPoint(coinpickup,transform.position);
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			//gameObject.renderer.enabled = false;
			hud.IncreaseScore(1000);
			Destroy(gameObject);
		}
	}
}