using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveBehaviour : MonoBehaviour {

	public PlayerBee playerBee;
	private float pollenPerSecond = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerBee != null && playerBee.IsInHive) {
			float pollenToTake = Time.deltaTime * pollenPerSecond;

			if (pollenToTake <= playerBee.pollenCollected) {
				GameStateManager.Instance.HivePollen += pollenToTake;
				playerBee.pollenCollected -= pollenToTake;
			} else {
				GameStateManager.Instance.HivePollen += playerBee.pollenCollected;
				playerBee.pollenCollected = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collisionInfo) {
		//Debug.LogWarning(" OnTriggerEnter2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
			playerBee.IsInHive = true;
		}
	}

	void OnTriggerExit2D(Collider2D collisionInfo) {
		//Debug.LogWarning(" OnTriggerExit2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
			playerBee.IsInHive = false;
		}
	}
}
