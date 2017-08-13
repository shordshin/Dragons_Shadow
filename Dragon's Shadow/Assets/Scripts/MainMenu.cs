using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture logo_menu;

	public float placementx1;
	public float placementx2;
	public float placementy1;
	public float placementy2;
	public float buttonsizex1;
	public float buttonsizex2;
	public float buttonsizey1;
	public float buttonsizey2;

	void OnGUI()
	{

		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), logo_menu);

		if(GUI.Button (new Rect(Screen.width * placementx1, Screen.height *placementy1, Screen.width * buttonsizex1, Screen.height * buttonsizey1)," "))
		{
			Application.LoadLevel(1);
			return;
		}

		//if(GUI.Button (new Rect(Screen.width * placementx2, Screen.height *placementy2, Screen.width * buttonsizex2, Screen.height * buttonsizey2)," "))
		//{
		//	Application.LoadLevel(1);
		//	return;
		//}

	}
}
