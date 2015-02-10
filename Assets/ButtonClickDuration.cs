using UnityEngine;
using System.Collections;

public class ButtonClickDuration : MonoBehaviour {
	
	
	float timeCurrent;
	float timeAtButtonDown ; 
	float timeAtButtonUp ;
	float timeButtonHeld = 0 ;
	bool draggable = false;
	
	void Start (){
		
	}
	
	void Update (){
		
		timeCurrent = Time.fixedTime;
		
	}
	
	void OnMouseDown(){
		timeAtButtonDown = timeCurrent;
		Debug.Log ("Time button pressed" + timeAtButtonDown);
	}
	
	void OnMouseUp (){
		timeAtButtonUp = timeCurrent;
		Debug.Log ("Time button released" + timeAtButtonUp);
		
		timeButtonHeld = (timeAtButtonUp - timeAtButtonDown);
		Debug.Log ("TimeButtonHeld = " + timeButtonHeld);
		
		if (timeButtonHeld > 2)
		{
			Debug.Log ("Yeah, you held the mouse for longer than 2 secs!!");
		}
	}
}