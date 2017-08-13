using UnityEngine;
using System.Collections;

public class LoadLevel2 : MonoBehaviour {

	void OnMouseEnter()
	{
		renderer.material.color = Color.red;
	}
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
		void OnMouseDown() {
		
		Application.LoadLevel(0);
		
	}
}
