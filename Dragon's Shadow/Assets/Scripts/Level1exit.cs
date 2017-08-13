using UnityEngine;
using System.Collections;

public class Level1exit : MonoBehaviour {

	HUDScript hud;

	void OnTriggerEnter(Collider other)
	{
		PlayerPhysics physics = other.gameObject.GetComponent<PlayerPhysics>();
		if (physics)
		{
			hud = GameObject.Find ("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(5000);
			Application.LoadLevel(2);
			return;
		}
		

	}
}
