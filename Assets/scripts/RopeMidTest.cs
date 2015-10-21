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

	void FixedUpdate()
	{
		var minimumDistance = 5.0;
		var maximumDistance = 30.0;
		
		var mínimumDistanceScale = 3.0;
		var maximumDistanceScale = 0.1;
		
		var distance = (transform.position - Camera.main.transform.position).magnitude;
		float norm =(float) ((distance - minimumDistance) / (maximumDistance - minimumDistance));
		norm = Mathf.Clamp01(norm);
		
		Vector3 minScale = new Vector3 (30, 30, 30);
		Vector3 maxScale = new Vector3 (5, 5, 5);
		
		GameObject.FindGameObjectWithTag("Arrow").transform.localScale = Vector3.Lerp(maxScale, minScale, norm);

		Debug.Log ("Bow position: " + GameObject.Find ("BowandArrow").transform.position);
		Debug.Log ("Mid position: " + GameObject.Find ("mid").transform.position);
		Debug.Log ("Difference " + (GameObject.Find ("BowandArrow").transform.position - GameObject.Find ("mid").transform.position));
	}

}
