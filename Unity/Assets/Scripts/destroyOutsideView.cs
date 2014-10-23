using UnityEngine;
using System.Collections;

public class destroyOutsideView : MonoBehaviour {
	
	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
