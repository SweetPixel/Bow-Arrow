using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	public void onButtonClick(string name)
	{
		if (name == "restart") {
			Application.LoadLevel("imageandroid");
			Debug.Log("restart");
		}
	}
}
