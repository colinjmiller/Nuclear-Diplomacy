using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	public GameObject plane;
	public GameObject groundTroopI;
	public GameObject planeSpawnRight;
	public GameObject planeSpawnLeft;
	public GameObject groundSpawnRight;
	public GameObject groundSpawnLeft;

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
		if (Time.frameCount % 300 == 0) {
			// Debug.Log("Spawning plane");
			spawnPlaneLeft(plane);
			//spawnPlaneRight(plane);
			//spawnGroundLeft(groundTroopI);
			//spawnGroundRight(groundTroopI);
		}
	}

	void spawnPlaneLeft(GameObject planeType) {
		GameObject planeClone = (GameObject) Instantiate (planeType, planeSpawnLeft.transform.position, Quaternion.identity);
		planeClone.GetComponent<movement>().moveLeft = false;
	}

	void spawnPlaneRight(GameObject planeType) {
		Instantiate (planeType, planeSpawnRight.transform.position, Quaternion.identity);
	}

	void spawnGroundLeft(GameObject groundType) {
		GameObject groundClone = (GameObject) Instantiate (groundType, groundSpawnLeft.transform.position, Quaternion.identity);
		groundClone.GetComponent<movement>().moveLeft = false;
	}

	void spawnGroundRight(GameObject groundType) {
		Instantiate (groundType, groundSpawnRight.transform.position, Quaternion.identity);
	}
}
