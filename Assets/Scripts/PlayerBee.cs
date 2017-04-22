using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBee : MonoBehaviour {

	public float energy = 100f; //0-100
	public float pollenCollected = 0f;
	public float maxPollen = 10f;
	public bool IsInHive = false;
	public bool IsSlowed = false;
	private float speed = 8f;

	private float energyLostPerSecond = 3f;
	private float energyRechargePerSecond = 20f;

	void Start () {
	}

	void Update () {
		if (IsInHive) {
			if (energy < 100f) {
				energy += (Time.deltaTime * energyRechargePerSecond);
				if (energy > 100f) { energy = 100f; }
			}
		} else {
			energy -= (Time.deltaTime * energyLostPerSecond);
		}
	}

	void FixedUpdate()
	{
		float actualSpeed = IsSlowed ? (speed / 3f) : speed;

		Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();

		if (IsSlowed) {
			rigidbody.drag = 3f;
		} else {
			rigidbody.drag = 0.5f;
		}

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//transform.Rotate (new Vector3 (0f, 0f, -moveHorizontal), Space.Self);

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
			
		rigidbody.AddForce (movement * actualSpeed);
	}
}
