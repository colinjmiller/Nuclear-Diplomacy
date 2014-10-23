using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public bool moveLeft;
	public float moveSpeed;
	
	void FixedUpdate() {
		int adjuster = moveLeft ? -1 : 1;
		rigidbody2D.velocity = new Vector2 (adjuster * moveSpeed, 0);
	}
}
