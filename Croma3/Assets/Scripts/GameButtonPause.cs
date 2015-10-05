using UnityEngine;
using System.Collections;

public class GameButtonPause : MonoBehaviour
{
    [SerializeField]
    GameManager manager;
    [SerializeField]
    private string nameScene;

	[SerializeField]
	private FadeFunction fade;
	
	void OnMouseDown ()
	{
		if(this.enabled)
		{
			if(nameScene != "")
			{
				fade.OnFadeLoadLevel(nameScene);
			}
		}
		Time.timeScale = 1;
		manager.Pause();
	}
}
