using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	float centerX, centerY;
	int level;
	// Use this for initialization
	void Start ()
	{
		level = 1;
		centerX = Screen.width / 2;
		centerY = Screen.height / 2;
	}
	
	// Update is called once per frame
	void OnGUI ()
	{
		level = (int)GUI.HorizontalSlider(new Rect(centerX - 60, centerY - 40, 120, 30), level, 1, 10);
		if(GUI.Button(new Rect(centerX - 50, centerY + 10, 100, 30), "START"))
		{
			GameManager.levelSelected = level;
			Application.LoadLevel("Game");
		}
	}
}
