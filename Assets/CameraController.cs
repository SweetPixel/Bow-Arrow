using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Quaternion rotation;

	// Use this for initialization
	void Awake () {
		rotation = transform.rotation;
	}

	void LateUpdate()
	{
		transform.rotation = rotation;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
