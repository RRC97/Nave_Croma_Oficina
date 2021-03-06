﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CubeMenuScript : MonoBehaviour
{
	int touchId = -1;
	Vector3 touchPos, touchLastPos, rotate;
	// Use this for initialization
	void Start ()
	{
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
						rotate = Vector3.zero;
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

				float x = touchLastPos.x - touchPos.x;
				float y = touchLastPos.y - touchPos.y;
				
				rotate += new Vector3(y, x);

				if(rotate.x > 30)rotate.x = 30;
				if(rotate.x < -30)rotate.x = -30;
				if(rotate.y > 30)rotate.y = 30;
				if(rotate.y < -30)rotate.y = -30;

				touchLastPos = touchPos;
			}
			else
			{
				if(touch.deltaTime > 1)
					rotate = Vector3.zero;
			}
		}
		else
		{
			rotate = Vector3.Lerp(rotate, Vector3.zero, 0.01f);
		}
		transform.Rotate(rotate);

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void Explosion ()
	{
		Transform cube = transform.GetChild(0);
		for(int i = 0; i < cube.childCount; i++)
		{
			Transform box = cube.GetChild(i);
			box.gameObject.AddComponent<Rigidbody>();
			box.GetComponent<Rigidbody> ().AddExplosionForce(Random.Range(0, 5000), cube.position, 1000);
		}
		enabled = false;
	}
}
