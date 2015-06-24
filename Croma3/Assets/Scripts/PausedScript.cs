using UnityEngine;
using System.Collections;

public class PausedScript : MonoBehaviour
{
	[SerializeField]
	GameObject bar;
	// Use this for initialization
	void Start ()
	{
		SpriteRenderer spriteRenderer = bar.GetComponent<SpriteRenderer>();
		spriteRenderer.color = BackgroundColor.invertColorText;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
