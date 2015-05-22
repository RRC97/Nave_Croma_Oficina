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
	}

	// Update is called once per frame
	void OnMouseDown ()
	{
		if(nameScene != "")
			Application.LoadLevel(nameScene);

		spriteRenderer.color = Color.black;
	}
}