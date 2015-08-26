using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoverManager : MonoBehaviour
{
	[SerializeField]
	Text best, value;
	// Use this for initialization
	void Awake ()
	{
		best.color = value.color = BackgroundColor.invertColorText;
	}
	
	// Update is called once per frame
	void Update ()
	{		
		best.text = "BEST: " + PlayerPrefs.GetInt ("Best");
		value.text = "SCORE: " + PlayerPrefs.GetInt ("Score");
	}
}
