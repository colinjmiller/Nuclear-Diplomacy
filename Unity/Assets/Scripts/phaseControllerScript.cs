using UnityEngine;
using System.Collections;

public class phaseControllerScript : MonoBehaviour {
	
	public float warSize = 6f;
	public float transitionSpeed = 1f;
	public GameObject text;
	public float peaceInterval = 10;
	public float warInterval = 10;
	public float warningInterval = 5;
	private float newSize;
	private float initSize;
	private float newY;
	private float initY;

	private float nextEvent;
	private bool peace;

	void Start() {
		initSize = Camera.main.orthographicSize;
		newSize = initSize;
		initY = Camera.main.transform.position.y;
		newY = initY;

		peace = true;
		nextEvent = Time.time + peaceInterval;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time >= nextEvent) {
			switchPhase();
		}
		phaseText ();
		positionCamera ();
	}
	
	void switchPhase() {
		newSize = (newSize == initSize) ? warSize : initSize;
		newY = (newY == initY) ? (initY + (warSize - initSize)) : initY;
		if (peace) {
			warInterval *= 1; // TODO: 2
			nextEvent += warInterval;
		} else {
			peaceInterval -= 0; // TODO: 10
			nextEvent += peaceInterval;
		}
		peace = !peace;
	}

	void positionCamera() {
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, newSize, Time.deltaTime * transitionSpeed);
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
		                                              new Vector3(0f, newY, Camera.main.transform.position.z), 
		                                              Time.deltaTime * transitionSpeed);
	}

	// If the phase is close to ending, let the player know
	void phaseText() {
		if (Time.time >= nextEvent - warningInterval) {
			text.guiText.color = new Color (1f, 1f, 1f, 1f);
			text.transform.FindChild("foregroundText").guiText.color = new Color (1f, 0f, 0f, 1f);
		} else {
			text.guiText.color = new Color(1f, 1f, 1f, 0f);
			text.transform.FindChild("foregroundText").guiText.color = new Color (1f, 0f, 0f, 0f);
		}
	}
}
