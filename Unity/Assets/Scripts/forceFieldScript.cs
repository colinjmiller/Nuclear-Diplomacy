using UnityEngine;
using System.Collections;

public class forceFieldScript : MonoBehaviour {

	public int health = 100;
	
	void OnCollisionEnter2D(Collision2D other) {
		health -= 5;
		Destroy (other.gameObject);
	}
}
