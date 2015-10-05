using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
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
	}
}
