using UnityEngine;
using System.Collections;
using System;

public class BackgroundColor : MonoBehaviour
{
	public static Color colorText;
	public static Color invertColorText;
	Color result;
	Color clear;
	Color dark;
	DateTime time, timeDark, timeclear;
	int timeBase = 11 * 60 + 59;
	int style = 0;
	Camera camera;
	// Use this for initialization
	void Awake ()
	{
		clear = new Color(255f/255, 255f/255, 255f/255);
		dark = new Color(51f/255, 53f/255, 51f/255);
		time = DateTime.Now;

		camera = GetComponent<Camera> ();

		style = PlayerPrefs.GetInt("SettingTheme", 0);

		if(style == 0)
			SetColor ();
		else if(style == 1)
		{
			camera.backgroundColor = clear;
			BackgroundColor.colorText = dark;
			BackgroundColor.invertColorText = clear;
		}
		else if(style == 2)
		{
			camera.backgroundColor = dark;
			BackgroundColor.colorText = clear;
			BackgroundColor.invertColorText = dark;
		}
		else
		{
			style = 0;
			SetColor();
		}
		
		Time.timeScale = 1;
	}

	void SetColor()
	{
		int timeInMinute = time.Hour * 60 + time.Minute;
		if(timeInMinute > timeBase)
		{
			float intensivite = (float)(timeInMinute - timeBase)/ timeBase;
			result = Color.Lerp(clear, dark, intensivite);
		}
		else
		{
			float intensivite = (float)timeInMinute/timeBase;
			result = Color.Lerp(dark, clear, intensivite);
		}

		if(timeInMinute > timeBase/2 && timeInMinute <= timeBase + timeBase/2)
		{
			BackgroundColor.colorText = dark;
			BackgroundColor.invertColorText = clear;
		}
		else
		{
			BackgroundColor.colorText = clear;
			BackgroundColor.invertColorText = dark;
		}
		
		camera.backgroundColor = result;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(style == 0 && DateTime.Now.Minute != time.Minute)
		{
			time = DateTime.Now;
			SetColor ();
		}
	}
}
