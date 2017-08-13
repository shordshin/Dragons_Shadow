using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform player;
	

	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (player.position.x, player.position.y, -10);
	}
}
