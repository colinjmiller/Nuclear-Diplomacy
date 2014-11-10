using UnityEngine;
using System.Collections;

public class createSmoke : MonoBehaviour {

	public GameObject smoke;

	void OnDestroy() {
		Debug.Log ("Creating smoke");
		Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
	}
}
