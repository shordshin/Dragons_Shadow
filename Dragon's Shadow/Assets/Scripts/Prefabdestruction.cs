using UnityEngine;
using System.Collections;

public class Prefabdestruction : MonoBehaviour {

	public float lifeSpan = 2.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
