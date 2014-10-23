using UnityEngine;
using System.Collections;

public class DetectCollisions : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collided!");
		HealthBar myHealth = GetComponent<HealthBar>();
		myHealth.barDisplay -= 20;
		Destroy (other.gameObject);
	}
}
