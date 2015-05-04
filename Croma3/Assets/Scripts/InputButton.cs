using UnityEngine;
using System.Collections;

public class InputButton : MonoBehaviour
{
	bool clicked;

	public bool IsClicked()
	{
		return clicked;
	}

	void Update ()
	{
		if(Input.touchCount > 0)
		{
			foreach(Touch touch in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
				if(hit.collider != null && hit.collider.transform == this.transform)
				{
					if(touch.phase == TouchPhase.Began)
					{
						clicked = true;
					}
				}
				if(touch.phase == TouchPhase.Ended)
				{
					clicked = false;
				}
			}
		}
		else
		{
			clicked = false;
		}
	}
}
