using UnityEngine;
using System.Collections;

public class PausedScript : MonoBehaviour
{
	Vector3 position;
	bool traveling;
	// Use this for initialization
	void Awake ()
	{
		position = transform.position;
		transform.position = position;
	}

	public void Travelling()
	{
		traveling = !traveling;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (traveling)
			position.y = Mathf.Lerp (position.y, 0, 0.1f);
		else
			position.y = Mathf.Lerp(position.y, 10f, 0.1f);

		transform.position = position;
	}
}
