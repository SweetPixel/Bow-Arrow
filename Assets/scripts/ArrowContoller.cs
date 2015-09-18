using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ArrowContoller : MonoBehaviour {
	Touch t;
	private Vector3 screenPoint;
	private Vector3 offset;
	public GameObject bow;
	public Text text;

	float startWidth = 0.2f;
	float endWidth = 0.2f;
	public Color startColor = Color.yellow;
	public Color endColor = Color.red;

	public GameObject leftPoint;
	public GameObject rightPoint;
	private LineRenderer line;
	public GameObject[] points;
	public float StartSize = .1f;
	public float EndSize = .1f;
	GameObject mid;
	void Start()
	{
		initialization ();
	}

	public void initialization()
	{
		mid= new GameObject();
		points [0] = rightPoint;
		points [1] = rightPoint;
		points [2] = leftPoint;
		CreateLine();
		RenderRope ();
	}

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
				mid.transform.position = t.position;
				points[1] = mid;
				RenderRope();
				Vector3 curScreenPoint = new Vector3 (t.position.x, t.position.y, screenPoint.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint), offset;
				bow.transform.position = curPosition;
			}

			if (t.phase == TouchPhase.Ended) {
				initialization();
			}

		}
	}

	void RenderRope()
	{
		if (line != null)
		{
			int counter = 0;
			foreach (var item in points)
			{
				line.SetPosition(counter, item.transform.position);
				counter++;
			}
		}
	}

	//Creates the LineRenderer
	private void CreateLine()
	{
		if (line == null)
		{
			line = points[0].AddComponent<LineRenderer>();
			line.SetVertexCount(points.Length);
			line.SetWidth(StartSize, EndSize);
			line.SetColors(Color.gray, Color.gray);

			/*(if (material != null)
			{
				line.material = material;
			}*/
		}
	}

}
