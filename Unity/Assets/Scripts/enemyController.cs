using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	public GameObject plane;
	public GameObject planeSpawnRight;

	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 200 == 0) {
			// Debug.Log("Spawning plane");
			// GameObject plane = Instantiate (plane, planeSpawnRight.transform.position, Quaternion.identity) as GameObject;
		}
	}
}
