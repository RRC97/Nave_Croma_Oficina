using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoverManager : MonoBehaviour
{
	[SerializeField]
	Text best, value;
	[SerializeField]
	SpriteRenderer button1, button2;
	// Use this for initialization
	void Awake ()
	{
		best.color = value.color = BackgroundColor.invertColorText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		button2.color = button1.color = BackgroundColor.invertColorText;
		
		best.text = "BEST: " + PlayerPrefs.GetInt ("Best");
		value.text = "SCORE: " + PlayerPrefs.GetInt ("Score");
	}
}
