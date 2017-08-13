using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		PlayerController controller = other.gameObject.GetComponent<PlayerController>();
		if (controller && controller.HasControl())
		{
			//let player die
			StartCoroutine(PlayerDeath(other.gameObject));

		}
	}

	IEnumerator PlayerDeath(GameObject player)
	{
		player.GetComponent<PlayerController>().PlayerDied();
		player.GetComponent<PlayerController>().RemoveControl();

		yield return new WaitForSeconds(2.5f);

		player.GetComponent<PlayerPhysics>().Reset();
		player.GetComponent<PlayerController>().PlayerLives();
		player.GetComponent<PlayerController>().GiveControl();
	}
}

