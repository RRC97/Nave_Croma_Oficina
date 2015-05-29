using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
	[SerializeField]
	private string nameScene;

	private SpriteRenderer spriteRenderer;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = BackgroundColor.colorText;
	}

	// Update is called once per frame
	void OnMouseDown ()
	{
		if(nameScene != "")
			Application.LoadLevel(nameScene);

		spriteRenderer.color = BackgroundColor.invertColorText;
	}
}