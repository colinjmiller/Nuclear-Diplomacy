using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour {

	public float damage;
	public GameObject smoke;
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		other.GetComponent<buildingController> ().reduceHealth (damage);
		GameObject smokeClone = (GameObject) Instantiate (smoke);
		smokeClone.transform.position = gameObject.transform.position;
		Destroy (gameObject);
	}
}
