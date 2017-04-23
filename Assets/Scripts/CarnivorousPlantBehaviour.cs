using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorousPlantBehaviour : MonoBehaviour {

	private PlayerBee playerBee;
	private float energyLostPerSecond = 20f;

	void Start () {
		
	}
		
	void Update () {
		if (playerBee != null && playerBee.IsSlowed) {
			playerBee.energy -= Time.deltaTime * energyLostPerSecond;
		}
	}

	void PlayChompSound(){
		AudioSource audioSource =  GetComponent<AudioSource> ();
		audioSource.PlayScheduled (Time.time);
	}

	void OnTriggerEnter2D(Collider2D collisionInfo) {
		Debug.LogWarning(" OnTriggerEnter2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
			playerBee.IsSlowed = true;

			PlayChompSound ();
		}
	}

	void OnTriggerExit2D(Collider2D collisionInfo) {
		Debug.LogWarning(" OnTriggerExit2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
			playerBee.IsSlowed = false;
		}
	}
}
