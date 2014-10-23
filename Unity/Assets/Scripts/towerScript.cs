using UnityEngine;
using System.Collections;

public class towerScript : MonoBehaviour {

	public int health = 100;
	public Sprite unselected;
	public Sprite selected;
	
	void OnCollisionEnter2D(Collision2D other) {
		health -= 40;
		Destroy (other.gameObject);
	}

	void OnMouseDown() {
		Sprite curSelection = GetComponent<SpriteRenderer> ().sprite;
		GetComponent<SpriteRenderer>().sprite = (curSelection == selected) ? unselected : selected;
	}

	void Update() {

		/*
		 *	Is the user pressing the left mouse button while the tower is selected? 
		 */
		if (Input.GetMouseButtonDown (0) && GetComponent<SpriteRenderer> ().sprite == selected) {
			Debug.Log ("You fired!");
		}
	}
}
