using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	InputButton[] buttons;
	BarScript bar;
	Sprite sprite;
	string spriteResult;
	int countPoints;
	// Use this for initialization
	void Awake ()
	{
		buttons = transform.GetComponentsInChildren<InputButton> ();
		bar = transform.FindChild ("Bar").GetComponent<BarScript>();
		spriteResult = "white";
	}
	
	// Update is called once per frame
	void Update ()
	{
		int activeResult = -1;
		int activeCount = 0;
		foreach(InputButton button in buttons)
		{
			if(button.IsClicked())
			{
				if(activeResult != -1)
				{
					activeResult += activeCount + 2;
				}
				else
				{
					activeResult = activeCount;
				}
			}
			activeCount++;
		}

		switch(activeResult)
		{
			case 0:
				spriteResult = "yellow";
				break;
			case 1:
				spriteResult = "red";
				break;
			case 2:
				spriteResult = "blue";
				break;
			case 3:
				spriteResult = "orange";
				break;
			case 4:
				spriteResult = "green";
				break;
			case 5:
				spriteResult = "magenta";
				break;
			case 7:
				spriteResult = "white";
				break;
		}

		bar.ResetSprite (spriteResult);
		countPoints = bar.GetValueHit() * 10;
	}
	
	public void OnGUI ()
	{
		GUIStyle label = GUI.skin.label;
		label.font = (Font)Resources.Load("Font/Neou");
		label.fontSize = Screen.height/20;
		label.alignment = TextAnchor.UpperRight;

		GUI.Label(new Rect(-5, 0, Screen.width, 100), ""+countPoints, label);
	}
}
