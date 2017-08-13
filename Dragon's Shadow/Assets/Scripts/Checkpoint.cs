using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		PlayerPhysics physics = other.gameObject.GetComponent<PlayerPhysics>();
		if (physics)
		{
			//set new respawn point
			physics.SetRespawnPoint(transform.position);
		}
	}
}