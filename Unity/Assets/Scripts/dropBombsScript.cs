using UnityEngine;
using System.Collections;

public class dropBombsScript : MonoBehaviour {

	public GameObject bomb;
	public GameObject target;
	public int numBombsToDrop = 5;
	public int framesBetween = 30;
	private int frameSinceBomb = 0;
	private int currentFrame = 0;
	private bool canDrop = false;

	// Update is called once per frame
	void Update () {
		currentFrame++;
		if (Mathf.Abs(transform.position.x - target.transform.position.x) < 7) {
			canDrop = true;
			// Debug.Log("Can drop");
		}

		if (canDrop && (currentFrame - frameSinceBomb) > framesBetween && numBombsToDrop > 0) {
			// Instantiate Bomb
			GameObject bombInstance = Instantiate (bomb, transform.position, Quaternion.identity) as GameObject;
			bombInstance.rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x * 50, 0));

			frameSinceBomb = currentFrame;
			numBombsToDrop--;
		}
	}
}
