using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
	[SerializeField]
	private string nameScene;

	// Update is called once per frame
	void OnMouseDown ()
	{
		if(nameScene != "")
			Application.LoadLevel(nameScene);
	}
}