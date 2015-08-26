using UnityEngine;
using System.Collections;

public class MenuPlayButton : MonoBehaviour
{
	[SerializeField]
	MenuBar bar;

	[SerializeField]
	MenuTitle title;

	bool active;
	float timeDisplay;
	
	// Update is called once per frame
	void Update ()
	{
		if(active)
		{
			timeDisplay += Time.deltaTime;

			if(timeDisplay > 1)
				Application.LoadLevel("Game");
		}
	}

	void OnMouseDown ()
	{
		if(this.enabled)
		{
			title.TravilingOff();
			bar.TravilingOff();
			active = true;
		}
	}
}
