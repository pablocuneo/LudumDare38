using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour {

	public float storedPollen = 2f;
	private float maxPollen = 2f;
	private float pollenRechargePerSecond = 0.1f;
	private float pollenPerSecond = 1f;

	private PlayerBee playerBee;

	void Start () {
	}

	void Update () {
		if (storedPollen < maxPollen) {
			float pollenToRecharge = Time.deltaTime * pollenRechargePerSecond;

			if (pollenToRecharge + storedPollen > maxPollen) {
				pollenToRecharge = maxPollen - storedPollen;
			}

			storedPollen += pollenToRecharge;
		}

		if (playerBee != null) {
			float pollenToGive = Time.deltaTime * pollenPerSecond;

			if (storedPollen >= pollenToGive) {
				if (playerBee.pollenCollected + pollenToGive > playerBee.maxPollen) {
					pollenToGive = playerBee.maxPollen - playerBee.pollenCollected;
				} 

				playerBee.pollenCollected += pollenToGive;
				storedPollen -= pollenToGive;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collisionInfo) {
		//Debug.LogWarning(" OnTriggerEnter2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
		}
	}
		
	void OnTriggerExit2D(Collider2D collisionInfo) {
		//Debug.LogWarning(" OnTriggerExit2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = null;
		}
	}
}
