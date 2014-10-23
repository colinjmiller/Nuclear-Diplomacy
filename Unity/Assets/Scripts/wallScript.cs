using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

	public int health = 100;

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log (other.collider.tag);
		if (other.collider.CompareTag ("Enemy")) {
			health -= 20;
			Destroy (other.gameObject);
		}
	}
}
