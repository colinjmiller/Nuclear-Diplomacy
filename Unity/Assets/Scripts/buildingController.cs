using UnityEngine;
using System.Collections;

public class buildingController : MonoBehaviour {

	public float health;
	public Sprite healthy;
	public Sprite healthySelected;
	public Sprite damaged;
	public Sprite damagedSelected;
	public Sprite destroyed;

	private float currentHealth;

	void Start() {
		currentHealth = health;
	}

	public void reduceHealth(float amount) {
		currentHealth -= amount;
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth > (health / 2)) {
			GetComponent<SpriteRenderer>().sprite = healthy;
		} else if (currentHealth <= 0) {
			GetComponent<SpriteRenderer>().sprite = destroyed;
		} else {
			GetComponent<SpriteRenderer>().sprite = damaged;
		}
	}
}
