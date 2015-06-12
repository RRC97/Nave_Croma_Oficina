using UnityEngine;
using System.Collections;

public class MenuPlayButton : MonoBehaviour
{
	[SerializeField]
	CubeMenuScript cube;

	[SerializeField]
	MenuBar bar;

	[SerializeField]
	MenuTitle title;

	bool active;
	float timeDisplay;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = BackgroundColor.colorText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(active)
		{
			timeDisplay += Time.deltaTime;

			if(timeDisplay > 1)
				Application.LoadLevel("Game");
		}
	}

	void OnMouseDown ()
	{
		if(this.enabled)
		{
			cube.Explosion();
			title.TravilingOff();
			bar.TravilingOff();
			active = true;
			spriteRenderer.color = BackgroundColor.invertColorText;
		}
	}
}
