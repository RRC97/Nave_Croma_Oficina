using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour
{
	private float volume;
	// Use this for initialization
	void Start ()
	{
		int index = PlayerPrefs.GetInt("SettingMusic", 0);
		volume = 1 - 0.35f * index;

		if(volume < 0)
			volume = 0;

		audio.volume = volume;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
