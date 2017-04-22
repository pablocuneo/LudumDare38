using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour {

	private float storedPollen = 2f;
	private float pollenPerSecond = 1f;

	protected PlayerBee playerBee;

	void Start () {
	}

	void Update () {
		//TODO: recover pollen slowly

		//TODO: give pollen while hovering
		if (playerBee != null) {
			float pollenToGive = Time.deltaTime * pollenPerSecond;

			if (storedPollen >= pollenToGive) {
				//TODO: check not to overflow bee with pollen
				playerBee.pollenCollected += pollenToGive;
				storedPollen -= pollenToGive;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collisionInfo) {
		Debug.LogWarning(" OnTriggerEnter2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
		}
	}
		
	void OnTriggerExit2D(Collider2D collisionInfo) {
		Debug.LogWarning(" OnTriggerExit2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = null;
		}
	}
}
