using UnityEngine;
using System.Collections;

public class SpriteColor : MonoBehaviour
{
	[SerializeField]
	private ColorOption option;

	private SpriteRenderer spriteRenderer;
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = option == ColorOption.BaseColor ?
			BackgroundColor.invertColorText : BackgroundColor.colorText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		spriteRenderer.color = option == ColorOption.BaseColor ?
			BackgroundColor.invertColorText : BackgroundColor.colorText;
	}
}
