using UnityEngine;
using System.Collections;
using System;

public class BackgroundColor : MonoBehaviour
{
	Color result;
	Color light;
	Color dark;
	DateTime time, timeDark, timeLight;
	// Use this for initialization
	void Awake ()
	{
		light = new Color(255f/255, 255f/255, 255f/255);
		dark = new Color(51f/255, 53f/255, 51f/255);
		time = DateTime.Now;
		int timeInMinute = time.Hour * 60 + time.Minute;
		int timeBase = 11 * 60 + 59;
		if(timeInMinute > timeBase)
		{
			float intensivite = (float)(timeInMinute - timeBase)/ timeBase;
			result = Color.Lerp(light, dark, intensivite);
		}
		else
		{
			float intensivite = (float)timeInMinute/timeBase;
			result = Color.Lerp(dark, light, intensivite);
		}

		//result = light;// + dark;

		camera.backgroundColor = result;
	}
	
	// Update is called once per frame
	void OnGUI ()
	{
		GUI.Label(new Rect(0, 0, 100, 100), ""+time.Hour);
	}
}
