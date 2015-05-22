using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CubeSettings : MonoBehaviour
{
	[SerializeField]
	private int capacity;

	[SerializeField]
	private string[] names;

	[SerializeField]
	private Text textResult;

	private Vector3 touchLastPos, touchPos, eulerAngles;
	private int touchId = -1, side;
	private bool rotate;
	private float rotation;

	// Use this for initialization
	void Start ()
	{
		eulerAngles = transform.eulerAngles;
		textResult.text = names[Value].ToUpper();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(touchId < 0 && Input.touchCount > 0)
		{
			foreach(Touch touch in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;
				Physics.Raycast(ray, out hit);
				if(hit.collider != null
				   && hit.collider.transform == this.transform)
				{
					if(touch.phase == TouchPhase.Began)
					{
						touchId = touch.fingerId;
						touchLastPos = touchPos = touch.deltaPosition;
					}
				}
			}
		}

		if(touchId >= 0)
		{
			Touch touch = Input.GetTouch(touchId);
			
			if(touch.phase == TouchPhase.Canceled
			   || touch.phase == TouchPhase.Ended)
			{
				touchId = -1;
				touchLastPos = touchPos = Vector3.zero;
			}
			else if(touch.phase == TouchPhase.Moved)
			{
				touchPos = touch.deltaPosition;
				
				float x = touchPos.x - touchLastPos.x;

				if(x > 10)
				{
					side = 1;
					touchId = -1;
					touchLastPos = touchPos = Vector3.zero;
					Value++;
					rotate = true;
				}

				if(x < -10)
				{
					side = -1;
					touchId = -1;
					touchLastPos = touchPos = Vector3.zero;
					Value--;
					rotate = true;
				}

			}
		}

		if(Value >= capacity)
		{
			Value = 0;
		}

		if (Value < 0)
		{
			Value = capacity - 1;
		}
	}
	void FixedUpdate()
	{
		if(rotate)
		{
			if(side < 0)
			{
				Vector3 eulerAngles = transform.eulerAngles;
				eulerAngles.y += 5;

				if((int)eulerAngles.y % 90 == 0)
				{
					eulerAngles.y = 0;
					rotate = false;
					textResult.text = names[Value].ToUpper();
				}

				transform.eulerAngles = eulerAngles;
			}
			if(side > 0)
			{
				Vector3 eulerAngles = transform.eulerAngles;
				eulerAngles.y -= 5;

				if((int)eulerAngles.y % 90 == 0)
				{
					eulerAngles.y = 0;
					rotate = false;
					textResult.text = names[Value].ToUpper();
				}

				transform.eulerAngles = eulerAngles;
			}
		}
	}

	public int Value
	{
		get; set;
	}
}
