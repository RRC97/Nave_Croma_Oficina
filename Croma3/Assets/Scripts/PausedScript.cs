using UnityEngine;
using System.Collections;

public class PausedScript : MonoBehaviour
{
	Vector3 position;
	bool on, traveling;
	// Use this for initialization
	void Awake ()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = BackgroundColor.colorText;
		position = transform.position;
		transform.position = position;
	}

	public void Travelling()
	{
		traveling = true;
	}

	public bool IsOn()
	{
		return on;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (traveling)
			position.y = Mathf.Lerp (position.y, 0, 0.1f);
		else
			position.y = Mathf.Lerp(position.y, 10f, 0.1f);

		if (!traveling)
		{
			if (position.y == 10)
				on = true;
			else
				on = false;
		}
		transform.position = position;
	}
}
