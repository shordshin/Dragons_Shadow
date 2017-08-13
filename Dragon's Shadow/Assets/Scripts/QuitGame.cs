using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
	
	public AudioClip confirmClip;
	
	void OnMouseEnter()
	{
		renderer.material.color = Color.red;
	}
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	void OnMouseDown() {
		AudioSource.PlayClipAtPoint(confirmClip, transform.position);
		Application.Quit();
	
	}
}