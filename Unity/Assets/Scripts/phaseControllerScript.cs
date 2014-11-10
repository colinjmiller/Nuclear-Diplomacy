using UnityEngine;
using System.Collections;

public class phaseControllerScript : MonoBehaviour {
	
	public float warSize = 6f;
	public float transitionSpeed = 1f;
	public GameObject text;
	public float peaceInterval = 10;
	public float warInterval = 10;
	public float warningInterval = 5;

	public GameObject peaceObjects;

	private float newSize;
	private float initSize;
	private float newY;
	private float initY;

	private float nextEvent;
	private int currentWarPhase;
	private bool peace;
	private bool transitioning;

	void Start() {
		initSize = Camera.main.orthographicSize;
		newSize = initSize;
		initY = Camera.main.transform.position.y;
		newY = initY;

		peace = true;
		transitioning = false;
		nextEvent = Time.time + peaceInterval;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time >= nextEvent && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
			switchPhase();
		}
		phaseText ();
		positionCamera ();
	}

	////////////////////////////////////
	// Getters
	////////////////////////////////////

	public bool isPeace() {
		return peace;
	}

	public bool canSpawn() {
		return !peace && !transitioning;
	}

	public int getWarPhase() {
		return currentWarPhase;
	}

	////////////////////////////////////
	// Private Helpers
	////////////////////////////////////
	
	private void switchPhase() {
		newSize = (newSize == initSize) ? warSize : initSize;
		newY = (newY == initY) ? (initY + (warSize - initSize)) : initY;
		if (peace) {
			startWarPhase();
		} else {
			startPeacePhase();
		}
		peace = !peace;
	}

	private void positionCamera() {
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, newSize, Time.deltaTime * transitionSpeed);
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
		                                              new Vector3(0f, newY, Camera.main.transform.position.z), 
		                                              Time.deltaTime * transitionSpeed);
	}

	// If the phase is close to ending, let the player know
	private void phaseText() {
		if (Time.time >= nextEvent - warningInterval) {
			// Show text
			transitioning = true;
			text.guiText.color = new Color (1f, 1f, 1f, 1f);
			text.transform.FindChild("foregroundText").guiText.color = new Color (1f, 0f, 0f, 1f);
		} else {
			// Hide text
			transitioning = false;
			text.guiText.color = new Color(1f, 1f, 1f, 0f);
			text.transform.FindChild("foregroundText").guiText.color = new Color (1f, 0f, 0f, 0f);
		}
	}

	private void startWarPhase() {
		currentWarPhase++;
		toggleVisibility (peaceObjects, false);
		warInterval *= 1; // TODO: 2
		nextEvent += warInterval;
	}

	private void startPeacePhase() {
		toggleVisibility (peaceObjects, true);
		peaceInterval -= 0; // TODO: 10
		nextEvent += peaceInterval;
	}

	// Toggles the visibility of obj GameObject and its children base on isVisible
	private void toggleVisibility(GameObject obj, bool isVisible) {
		obj.renderer.enabled = isVisible;
		Renderer[] renderers = obj.GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in renderers) {
			r.enabled = isVisible;
		}
	}
}
