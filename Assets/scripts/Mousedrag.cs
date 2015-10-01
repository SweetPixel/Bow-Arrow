using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Mousedrag : MonoBehaviour 
{
	public Text test;
	private Vector3 screenPoint;
	private Vector3 offset;
	Touch t;

	void Update(){
		if (Input.touchCount > 0) {
			t = Input.touches[0];
			//foreach(Touch t in Input.touches){
				if (t.phase == TouchPhase.Began){

					screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, screenPoint.z));
				}

				if(t.phase == TouchPhase.Moved){

					Vector3 curScreenPoint = new Vector3(t.position.x, t.position.y, screenPoint.z);
					Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) , offset;
					transform.position = curPosition;
				//Debug.Log("Bow pos" + curPosition);
				}
			//}
		}
	}


	/*void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}*/
	
	/*void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) , offset;
		transform.position = curPosition;
		
	}*/
	
}