using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform myTarget;
	public float minY = 2f;

	void Update () {
		if(myTarget != null) {
			Vector3 targPos = myTarget.position;
			targPos.z = transform.position.z;

			Vector3	newPosition = Vector3.Lerp (transform.position, targPos, 0.1f);
			newPosition.y = (newPosition.y < minY) ? minY : newPosition.y;
			transform.position = newPosition;
			//TODO: Prevent the camera from going too low (or too high)
		}
	}
}
