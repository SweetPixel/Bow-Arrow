using UnityEngine;
using System.Collections;

public class destroyArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyArrow ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator DestroyArrow()
	{
		yield return new WaitForSeconds(2f);
		Destroy (this.gameObject);
	}
}
