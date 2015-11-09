using UnityEngine;
using System.Collections;

public class touchExample : MonoBehaviour {
	/*  FOR SWIPE BASED MOVEMENT
	 public float speed = 0.1F;
	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Rotate( -touchDeltaPosition.y * speed,-touchDeltaPosition.x * speed, 0);
		}

	}*/

	//FOR ACCELEROMETER BASED MOVEMENT
	float hRotation = 0.0f;    //Horizontal angle
	float vRotation = 0.0f;   //Vertical rotation angle of the camera
	float cameraMovementSpeed = 0.5f;
	void Update() {

		hRotation -= (Input.acceleration.y+1) * cameraMovementSpeed;
		vRotation += Input.acceleration.x * cameraMovementSpeed;
		transform.rotation = Quaternion.Euler( hRotation,vRotation, 0.0f);
		
	}
}