using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
	[SerializeField]
	private string nameScene;
	private SpriteRenderer spriteRenderer;
	
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = BackgroundColor.colorText;
	}
	
	void OnMouseDown ()
	{
		if(this.enabled)
		{
			if(nameScene != "")
				Application.LoadLevel(nameScene);
			
			spriteRenderer.color = BackgroundColor.invertColorText;
		}
	}
}
