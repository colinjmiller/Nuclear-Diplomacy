using UnityEngine;
using System.Collections;

public class buildItemScript : MonoBehaviour {

	public Transform item;
	public GameObject primaryPosition;
	public GameObject secondaryPosition;
	
	void OnMouseDown() {
		Debug.Log ("Making Wall");
		Instantiate (item, primaryPosition.transform.position, Quaternion.identity);
		if (secondaryPosition) {
			Instantiate (item, secondaryPosition.transform.position, Quaternion.identity);
		}
	}

	void OnMouseOver() {
		Debug.Log ("Hovering");
	}
}
