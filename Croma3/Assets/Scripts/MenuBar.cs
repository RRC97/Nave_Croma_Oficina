using UnityEngine;
using System.Collections;

public class MenuBar : MonoBehaviour
{
	
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = BackgroundColor.invertColorText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
