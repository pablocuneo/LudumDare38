using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform myTarget;

	void Update () {
		if(myTarget != null) {
			Vector3 targPos = myTarget.position;
			targPos.z = transform.position.z;

			transform.position = Vector3.Lerp(transform.position,targPos, 0.1f);
			//TODO: Prevent the camera from going too low (or too high)
		}
	}
}
