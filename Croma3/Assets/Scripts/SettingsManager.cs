using UnityEngine;
using System.Collections;

public class SettingsManager : MonoBehaviour
{
	[SerializeField]
	private CubeSettings cubeTheme, cubeSound, cubeTutorial, cubeMusic;

	void Awake()
	{
		cubeTheme.Value = PlayerPrefs.GetInt("SettingTheme");
		cubeSound.Value = PlayerPrefs.GetInt("SettingSound");
		cubeTutorial.Value = PlayerPrefs.GetInt("SettingTutorial");
		cubeMusic.Value = PlayerPrefs.GetInt("SettingMusic");
	}
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("Menu");
			PlayerPrefs.SetInt("SettingTheme", cubeTheme.Value);
			PlayerPrefs.SetInt("SettingSound", cubeSound.Value);
			PlayerPrefs.SetInt("SettingTutorial", cubeTutorial.Value);
			PlayerPrefs.SetInt("SettingMusic", cubeMusic.Value);
		}
	}
}
