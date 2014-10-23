using UnityEngine;
using System.Collections;

public class antiAircraftScript : MonoBehaviour {

	public int health = 100;
	public Sprite unselected;
	public Sprite selected;
	
	void OnCollisionEnter2D(Collision2D other) {
		health -= 50;
		Destroy (other.gameObject);
	}
	
	void OnMouseDown() {
		Sprite curSelection = GetComponent<SpriteRenderer> ().sprite;
		GetComponent<SpriteRenderer>().sprite = (curSelection == selected) ? unselected : selected;
	}
	
	void Update() {
		
		/*
		 *	Is the user pressing the left mouse button while the object is selected? 
		 */
		if (Input.GetMouseButtonDown (0) && GetComponent<SpriteRenderer> ().sprite == selected) {
			Debug.Log ("You fired!");
		}
	}
}
