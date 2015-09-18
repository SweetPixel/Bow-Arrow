using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ArrowContoller : MonoBehaviour {
	Touch t;
	private Vector3 screenPoint;
	private Vector3 offset;
	public GameObject bow;
	public Text text;

	void Update(){
		if (Input.touchCount > 1) {
			t = Input.touches [1];
			if (t.phase == TouchPhase.Began) {
				text.text = t.position.x.ToString();
				screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
				offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (t.position.x, t.position.y, screenPoint.z));
			}
			
			if (t.phase == TouchPhase.Moved) {
				text.text = t.position.x.ToString();
				Vector3 curScreenPoint = new Vector3 (t.position.x, t.position.y, screenPoint.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint), offset;
				bow.transform.position = curPosition;
			}

		}
	}
}
