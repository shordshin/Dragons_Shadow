using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float playerScore = 9000;
	
	void Update () 
	{
		playerScore -=  (Time.deltaTime * 100);
	}

	public void IncreaseScore(int amount)
	{
		playerScore += amount;
	}
	 void OnDisable()
	{
		PlayerPrefs.SetInt ("Score", (int)playerScore);
	}

	void OnGUI()
	{
		GUILayout.Label ("Esc: Pause");
		GUI.Label(new Rect(Screen.width/2, 20, Screen.width/2, 500), "Score: " + (int)(playerScore));
	}
}