using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.transform.Rotate (new Vector3(67,60f,140));
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate (new Vector3(gameObject.transform.rotation.x,gameObject.transform.rotation.y+0.2f,gameObject.transform.rotation.z));
	}
}
