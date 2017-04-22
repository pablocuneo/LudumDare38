using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	void Start()
	{
	}
		
	void FixedUpdate()
	{
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//transform.Rotate (new Vector3 (0f, 0f, -moveHorizontal), Space.Self);

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rigidbody.AddForce (movement * speed);
	}
}
