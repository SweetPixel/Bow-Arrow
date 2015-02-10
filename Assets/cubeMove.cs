using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cubeMove : MonoBehaviour {
	
	//public float playerSpeed;
	public GameObject CapsulePrefab;//shoot script is attached  
	//to this prefab
		public float angle = 45.0f;
	public GameObject clone;
	public float force = 1000.0f;
	
	
	// Update is called once per frame
	void Update () 
	{
		// to move the player(cube)
		float amtToMove = Input.GetAxis("Horizontal")*Time.deltaTime;
		transform.Translate(Vector3.right*amtToMove);
		
		
		
		if (Input.GetMouseButtonUp(0))// ("Fire1"))
		{
			clone = Instantiate(CapsulePrefab,transform.position,Quaternion.Euler(0,0,angle)) as GameObject;
			clone.rigidbody.AddForce(Vector3.forward*force);
		}
	}
	
}