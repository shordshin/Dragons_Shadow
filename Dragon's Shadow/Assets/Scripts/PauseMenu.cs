using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	bool paused = false;
	
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			{
						
			paused = togglePause ();
			}
	}
	
	void OnGUI()
	{
		if(paused)
		{
			GUILayout.Label("PAUSED!");
			if(GUILayout.Button("Continue"))
				paused = togglePause();
		}
	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}
}





/*using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool isPaused;
	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		//pause game
		if (Input.GetKeyDown (KeyCode.Escape)) {
						Pause ();
				}
		}
		
	void Pause(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			isPaused = true;
		}
		else
		{
			Time.timeScale = 1;
			isPaused = false;
		}
	}
	void onGUI() 
	{
		if (isPaused)
		{
			if(GUI.Button (Rect((Screen.width)/2,480,140,70), "Quit", "button2"))
			{
				print("Quit!");
				Application.Quit();
			}
			if(GUI.Button (Rect((Screen.width)/2,560,140,70), "Restart", "button2"))
			{
				print("Restart");
				Application.LoadLevel("SomeLevelHere");
				Pause ();
				isPaused = false;
			}
			if(GUI.Button (Rect((Screen.width)/2,640,140,70), "Continue", "button2"))
			{
				print("Continue");
				Pause ();
				isPaused = false;   
			}
		}
	}
}*/