using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
	[SerializeField]
	private string nameScene;
	
	void OnMouseDown ()
	{
		if(this.enabled)
		{
			if(nameScene != "")
				Application.LoadLevel(nameScene);
		}
	}
}
