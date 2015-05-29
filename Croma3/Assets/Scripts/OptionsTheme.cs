using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsTheme : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;


	[SerializeField]
	private Text[] texts;
	// Use this for initialization
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = BackgroundColor.invertColorText;

		foreach (Text text in texts)
			text.color = BackgroundColor.colorText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
