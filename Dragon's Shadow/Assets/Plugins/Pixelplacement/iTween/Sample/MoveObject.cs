using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{	
	public float xDistance;
	public float yDistance;
	public float zDistance;
	public float speed;
	//public float ease;
	//public float easeInOutExpo;
	//public float loopType;
	//public float pingpong;
	public float delay;

	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("x", xDistance, "y", yDistance, "z", zDistance, "speed", speed, "easeType", "easeInOutExpo",  "loopType", "pingPong",  "delay", delay));
	}
}

