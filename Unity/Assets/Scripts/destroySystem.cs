using UnityEngine;
using System.Collections;

public class destroySystem : MonoBehaviour {

	private ParticleSystem system;

	void Start() {
		system = GetComponent<ParticleSystem> ();
	}
	
	void Update () {
		if (!system.IsAlive ()) {
			Destroy(gameObject);
		}
	}
}
