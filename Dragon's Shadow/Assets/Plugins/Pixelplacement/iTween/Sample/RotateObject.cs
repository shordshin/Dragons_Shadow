using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{	
	public float x;
	public float y;
	public float z;
	public float delay;
	public float speed;

	void Start(){
		iTween.RotateBy(gameObject, iTween.Hash("x", x, "y", y, "z", z, "speed", speed, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", delay));
	}
}

