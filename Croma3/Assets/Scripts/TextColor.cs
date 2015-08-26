using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextColor : MonoBehaviour
{
	[SerializeField]
	private ColorOption option;

	private Text textRenderer;
	void Awake ()
	{
		textRenderer = GetComponent<Text> ();
		textRenderer.color = option == ColorOption.BaseColor ?
			BackgroundColor.invertColorText : BackgroundColor.colorText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		textRenderer.color = option == ColorOption.BaseColor ?
			BackgroundColor.invertColorText : BackgroundColor.colorText;
	}
}
