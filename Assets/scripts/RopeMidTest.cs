using UnityEngine;
using System.Collections;

public class RopeMidTest : MonoBehaviour {

		Touch t;
		private Vector3 screenPoint;
		private Vector3 offset;
		public Sprite onlyBow;
		public Sprite BowandArrow;

		
		void Update()
			{
					if (Input.touchCount > 1) 
				{
						t = Input.touches [1];
						if (t.phase == TouchPhase.Began)
						{
							screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
							offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, screenPoint.z));
						}
						
						if (t.phase == TouchPhase.Moved) 
						{
							GameObject.Find("BowandArrow").GetComponent<SpriteRenderer>().sprite=onlyBow;
							GameObject.Find("Still Arrow").GetComponent<MeshRenderer>().enabled=true;
							Vector3 curScreenPoint = new Vector3(t.position.x, t.position.y, screenPoint.z);
							Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) , offset;
							transform.position = curPosition;
						}
						if (t.phase == TouchPhase.Ended) 
						{
							GameObject.Find("BowandArrow").GetComponent<SpriteRenderer>().sprite=BowandArrow;
							GameObject.Find("Still Arrow").GetComponent<MeshRenderer>().enabled=false;
							resetString();
						}
				}
			}
	void resetString()
		{
		this.gameObject.transform.position = new Vector3 (0,0,0);
		}
}
