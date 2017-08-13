using UnityEngine;
using System.Collections;

public class DestroyExplosion : MonoBehaviour {

	public GameObject pointLight;

	void Start () {
		Destroy(pointLight, 0.1f);
		Destroy(gameObject, 0.1f);
	}
}