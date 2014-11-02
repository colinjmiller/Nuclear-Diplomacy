using UnityEngine;
using System.Collections;

public class phaseControllerScript : MonoBehaviour {
	
	public float warSize = 6f;
	public float transitionSpeed = 1f;
	private float newSize;
	private float initSize;
	private float newY;
	private float initY;

	void Start() {
		initSize = Camera.main.orthographicSize;
		newSize = initSize;
		initY = Camera.main.transform.position.y;
		newY = initY;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			newSize = (newSize == initSize) ? warSize : initSize;
			newY = (newY == initY) ? (initY + (warSize - initSize)) : initY;
		}
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, newSize, Time.deltaTime * transitionSpeed);
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
		                                              new Vector3(0f, newY, Camera.main.transform.position.z), 
		                                              Time.deltaTime * transitionSpeed);
	}
}
