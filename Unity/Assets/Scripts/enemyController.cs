using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	public GameObject plane;
	public GameObject planeSpawnRight;

	private phaseControllerScript phaseController;

	void Start() {
		phaseController = GameObject.Find ("phaseController").GetComponent<phaseControllerScript> ();
	}

	void Update () {
		if (phaseController.canSpawn()) {
			spawnEnemies();
		}
	}

	void spawnEnemies() {
		if (Time.frameCount % 200 == 0) {
			// Debug.Log("Spawning plane");
			GameObject planeClone = (GameObject) Instantiate (plane, planeSpawnRight.transform.position, Quaternion.identity);
		}
	}
}
