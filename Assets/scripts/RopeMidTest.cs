using UnityEngine;
using System.Collections;

public class RopeMidTest : MonoBehaviour {

		Touch t;
		private Vector3 screenPoint;
		private Vector3 offset;

		public LineRenderer top;
		public LineRenderer bottom;

	//	GameObject mid;
		
		void Start()
		{
			this.gameObject.GetComponent<MeshRenderer>().enabled=false;
		}
		
		void Update(){
			if (Input.touchCount > 1) 
		{
				t = Input.touches [1];
				if (t.phase == TouchPhase.Began)
				{
					GameObject.Find("BowTopPoint").GetComponent<LineRenderer>();
					this.gameObject.GetComponent<MeshRenderer>().enabled=true;
					screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, screenPoint.z));
				}
				
				if (t.phase == TouchPhase.Moved) 
				{
					Vector3 curScreenPoint = new Vector3(t.position.x, t.position.y, screenPoint.z);
					Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) , offset;
					transform.position = curPosition;
				}
				
				if (t.phase == TouchPhase.Ended) 
				{
					this.gameObject.GetComponent<MeshRenderer>().enabled=false;
				}

			}
		}
	}
