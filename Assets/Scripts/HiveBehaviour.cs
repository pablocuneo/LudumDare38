using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collisionInfo) {
		//Debug.LogWarning(" OnTriggerEnter2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			PlayerBee playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
			playerBee.IsInHive = true;
		}
	}

	void OnTriggerExit2D(Collider2D collisionInfo) {
		//Debug.LogWarning(" OnTriggerExit2D:  " + collisionInfo.gameObject.tag);

		if (collisionInfo.gameObject.tag == "Player") {
			PlayerBee playerBee = collisionInfo.gameObject.GetComponent<PlayerBee> ();
			playerBee.IsInHive = false;
		}
	}
}
