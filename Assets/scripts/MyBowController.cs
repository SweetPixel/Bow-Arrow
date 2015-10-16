using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MyBowController : MonoBehaviour {
	
	public Text test;
	private Vector3 screenPoint= Vector3.zero;
	private Vector3 offset = Vector3.zero;
	Touch t;
	
	void Update(){
		if (Input.touchCount > 0) {
			t = Input.touches[0];
			//foreach(Touch t in Input.touches){
			if (t.phase == TouchPhase.Began){
				
		 	screenPoint = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, screenPoint.z));
			}
			
			if(t.phase == TouchPhase.Moved){
				
				Vector3 curScreenPoint = new Vector3(t.position.x, t.position.y, screenPoint.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) , offset;
				transform.position = curPosition;
				Debug.Log("Bow" + curScreenPoint);

				ArrowContoller arrow = GameObject.Find("BowObject").GetComponent<ArrowContoller>();
				arrow.initialization();
//				Debug.Log ("ScreenPointBow"+ screenPoint + "offsetBow"+ offset + "curScreenPointBOW"+ curScreenPoint + "curPositionBOW" +curPosition);

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
