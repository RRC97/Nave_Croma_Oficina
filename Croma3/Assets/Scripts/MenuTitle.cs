using UnityEngine;
using System.Collections;

public class MenuTitle : MonoBehaviour
{
	private Vector3 position;
	private SpriteRenderer spriteRenderer;
	private bool posCorrect;
	private float aux;
	private bool on = true;
	// Use this for initialization
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = BackgroundColor.colorText;
		position = transform.position;
		transform.position = position;
	}
	
	public void TravilingOff()
	{
		on = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{		
		if(on) position.y = Mathf.Lerp(position.y, 4f, 0.1f);
		else position.y = Mathf.Lerp(position.y, 10f, 0.1f);
		
		transform.position = position;
	}
}
